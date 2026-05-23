using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Text.Json;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context) { _context = context; }

        public async Task<IActionResult> Shop(string category, string search)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(category))
                query = query.Where(p => p.Category == category);
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Name!.Contains(search) || p.Category!.Contains(search));
            ViewBag.Categories = await _context.Products.Select(p => p.Category).Distinct().ToListAsync();
            ViewBag.Search = search;
            ViewBag.SelectedCategory = category;
            return View(await query.ToListAsync());
        }

        public async Task<IActionResult> Detail(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        public async Task<IActionResult> Index()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail)) return RedirectToAction("Login", "Account");
            if (userRole != "Admin" && userRole != "SuperAdmin") return RedirectToAction("Login", "Account");

            List<Product> products;
            if (userRole == "SuperAdmin")
                products = await _context.Products.ToListAsync();
            else
                products = await _context.Products.Where(p => p.CreatedByEmail == userEmail).ToListAsync();

            ViewBag.TotalProducts = await _context.Products.CountAsync();
            ViewBag.TotalUsers = await _context.Users.CountAsync();
            ViewBag.TotalOrders = await _context.Orders.CountAsync();
            ViewBag.TotalRevenue = _context.Orders.AsEnumerable().Sum(o => o.TotalAmount);
            ViewBag.MyProducts = products.Count;
            return View(products);
        }

        public IActionResult Create()
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail) || (userRole != "Admin" && userRole != "SuperAdmin"))
                return RedirectToAction("Login", "Account");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile? imageFile)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail)) return RedirectToAction("Login", "Account");

            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);
                using var stream = new FileStream(savePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                product.ImageUrl = "/uploads/" + fileName;
            }

            product.CreatedByEmail = userEmail;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            TempData["CartMessage"] = "Product added successfully!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            var userEmail = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail)) return RedirectToAction("Login", "Account");
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            if (userRole != "SuperAdmin" && product.CreatedByEmail != userEmail) return Unauthorized();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile? imageFile)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var userRole = HttpContext.Session.GetString("UserRole");
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return NotFound();
            if (userRole != "SuperAdmin" && existing.CreatedByEmail != userEmail) return Unauthorized();

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Category = product.Category;
            existing.Description = product.Description;

            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath)!);
                using var stream = new FileStream(savePath, FileMode.Create);
                await imageFile.CopyToAsync(stream);
                existing.ImageUrl = "/uploads/" + fileName;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var userRole = HttpContext.Session.GetString("UserRole");
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            if (userRole != "SuperAdmin" && product.CreatedByEmail != userEmail) return Unauthorized();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Cart()
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            var cart = string.IsNullOrEmpty(cartJson)
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(cartJson)!;
            ViewBag.Subtotal = cart.Sum(c => c.Product.Price * c.Quantity);
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            var cartJson = HttpContext.Session.GetString("Cart");
            var cart = string.IsNullOrEmpty(cartJson)
                ? new List<CartItem>()
                : JsonSerializer.Deserialize<List<CartItem>>(cartJson)!;
            var existing = cart.FirstOrDefault(c => c.Product.Id == id);
            if (existing != null) existing.Quantity++;
            else cart.Add(new CartItem { Product = product, Quantity = 1 });
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
            TempData["CartMessage"] = $"{product.Name} added to cart!";
            return RedirectToAction("Shop");
        }

        [HttpPost]
        public async Task<IActionResult> BuyNow(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            var cart = new List<CartItem> { new CartItem { Product = product, Quantity = 1 } };
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (!string.IsNullOrEmpty(cartJson))
            {
                var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson)!;
                var item = cart.FirstOrDefault(c => c.Product.Id == id);
                if (item != null)
                {
                    if (quantity <= 0) cart.Remove(item);
                    else item.Quantity = quantity;
                }
                HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
            }
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (!string.IsNullOrEmpty(cartJson))
            {
                var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson)!;
                var item = cart.FirstOrDefault(c => c.Product.Id == id);
                if (item != null) cart.Remove(item);
                HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
            }
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(string fullName, string phone, string address, string paymentMethod)
        {
            var cartJson = HttpContext.Session.GetString("Cart");
            if (string.IsNullOrEmpty(cartJson)) return RedirectToAction("Cart");
            var cart = JsonSerializer.Deserialize<List<CartItem>>(cartJson)!;
            var userEmail = HttpContext.Session.GetString("UserEmail") ?? "guest@daraz.com";
            var order = new Order
            {
                UserEmail = userEmail,
                UserName = fullName,
                Phone = phone,
                ShippingAddress = address,
                PaymentMethod = paymentMethod,
                ProductNames = string.Join(", ", cart.Select(c => $"{c.Product.Name} x{c.Quantity}")),
                TotalAmount = cart.Sum(c => c.Product.Price * c.Quantity),
                Status = "Pending",
                OrderDate = DateTime.Now
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            HttpContext.Session.Remove("Cart");
            TempData["OrderSuccess"] = $"Order placed! Total: Rs. {order.TotalAmount:N0}";
            return RedirectToAction("OrderHistory");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Cart");
        }

        public async Task<IActionResult> OrderHistory()
        {
            var userEmail = HttpContext.Session.GetString("UserEmail");
            var userRole = HttpContext.Session.GetString("UserRole");
            if (string.IsNullOrEmpty(userEmail)) return RedirectToAction("Login", "Account");
            List<Order> orders;
            if (userRole == "SuperAdmin")
                orders = await _context.Orders.OrderByDescending(o => o.OrderDate).ToListAsync();
            else
                orders = await _context.Orders.Where(o => o.UserEmail == userEmail)
                    .OrderByDescending(o => o.OrderDate).ToListAsync();
            return View(orders);
        }
    }
}