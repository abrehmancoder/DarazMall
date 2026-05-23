using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Shop}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Users.Any(u => u.Role == "SuperAdmin"))
    {
        context.Users.Add(new User
        {
            FullName = "Super Admin",
            Email = "superadmin@daraz.com",
            Password = "superadmin123",
            Role = "SuperAdmin"
        });
        context.SaveChanges();
    }

    if (!context.Products.Any(p => p.CreatedByEmail == "system@daraz.com"))
    {
        var products = new List<Product>
        {
            new Product { Name = "Samsung Galaxy S24 Ultra", Price = 289000, Category = "Electronics", Description = "200MP camera, Snapdragon 8 Gen 3, 5000mAh battery, S-Pen included.", ImageUrl = "https://images.unsplash.com/photo-1610945415295-d9bbf067e59c?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "iPhone 15 Pro Max", Price = 349000, Category = "Electronics", Description = "A17 Pro chip, titanium design, 48MP main camera, USB-C.", ImageUrl = "https://images.unsplash.com/photo-1696446702183-a6fd19dbbdc8?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Google Pixel 8 Pro", Price = 198000, Category = "Electronics", Description = "Google Tensor G3, 50MP camera, 7 years of updates.", ImageUrl = "https://images.unsplash.com/photo-1598327105666-5b89351aff97?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "OnePlus 12", Price = 159000, Category = "Electronics", Description = "Snapdragon 8 Gen 3, Hasselblad camera, 100W charging.", ImageUrl = "https://images.unsplash.com/photo-1585060544812-6b45742d762f?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Xiaomi 14 Pro", Price = 145000, Category = "Electronics", Description = "Leica optics, 120W HyperCharge, AMOLED display.", ImageUrl = "https://images.unsplash.com/photo-1574944985070-8f3ebc6b79d2?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Sony WH-1000XM5", Price = 89000, Category = "Electronics", Description = "Industry-leading noise cancellation, 30hr battery, multipoint connection.", ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Apple AirPods Pro 2", Price = 65000, Category = "Electronics", Description = "Active noise cancellation, Adaptive Audio, H2 chip.", ImageUrl = "https://images.unsplash.com/photo-1600294037681-c80b4cb5b434?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Samsung 65\" QLED 4K TV", Price = 245000, Category = "Electronics", Description = "Quantum Dot technology, 120Hz, Smart TV with Tizen OS.", ImageUrl = "https://images.unsplash.com/photo-1593359677879-a4bb92f829e1?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Dell XPS 15 Laptop", Price = 320000, Category = "Electronics", Description = "Intel i7-13700H, RTX 4060, 16GB RAM, OLED display.", ImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "MacBook Pro 14\" M3", Price = 420000, Category = "Electronics", Description = "Apple M3 Pro chip, 18GB RAM, 18hr battery, Liquid Retina XDR.", ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "iPad Pro 12.9\" M2", Price = 195000, Category = "Electronics", Description = "M2 chip, Liquid Retina XDR, Apple Pencil 2 support.", ImageUrl = "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Canon EOS R6 Mark II", Price = 385000, Category = "Electronics", Description = "40fps burst, 6K RAW video, dual card slots, weather sealed.", ImageUrl = "https://images.unsplash.com/photo-1516035069371-29a1b244cc32?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "PlayStation 5", Price = 125000, Category = "Electronics", Description = "4K gaming, SSD storage, DualSense controller, ray tracing.", ImageUrl = "https://images.unsplash.com/photo-1606813907291-d86efa9b94db?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Xbox Series X", Price = 115000, Category = "Electronics", Description = "4K 120fps, 1TB SSD, Game Pass compatible, backward compatible.", ImageUrl = "https://images.unsplash.com/photo-1621259182978-fbf93132d53d?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Samsung Galaxy Tab S9", Price = 145000, Category = "Electronics", Description = "Snapdragon 8 Gen 2, AMOLED display, IP68, S-Pen included.", ImageUrl = "https://images.unsplash.com/photo-1561154464-82e9adf32764?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Levi's 501 Original Jeans", Price = 8500, Category = "Men's Fashion", Description = "Classic straight fit, 100% cotton denim, iconic style.", ImageUrl = "https://images.unsplash.com/photo-1542272604-787c3835535d?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Nike Air Force 1", Price = 18500, Category = "Men's Fashion", Description = "Classic white leather sneaker, Air cushioning, timeless design.", ImageUrl = "https://images.unsplash.com/photo-1549298916-b41d501d3772?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Adidas Ultraboost 23", Price = 22000, Category = "Men's Fashion", Description = "Boost midsole, Primeknit upper, Continental rubber outsole.", ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Men's Formal Suit", Price = 15000, Category = "Men's Fashion", Description = "Slim fit, wool blend, available in navy and charcoal.", ImageUrl = "https://images.unsplash.com/photo-1507679799987-c73779587ccf?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Ralph Lauren Polo Shirt", Price = 6500, Category = "Men's Fashion", Description = "Classic pique cotton, embroidered logo, multiple colors.", ImageUrl = "https://images.unsplash.com/photo-1586790170083-2f9ceadc732d?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Women's Lawn Suit 3-Piece", Price = 4500, Category = "Women's Fashion", Description = "Printed lawn fabric, embroidered neckline, Pakistani design.", ImageUrl = "https://images.unsplash.com/photo-1583391733956-6c78276477e2?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Khaadi Printed Kurta", Price = 3200, Category = "Women's Fashion", Description = "100% cotton, block printed, A-line style.", ImageUrl = "https://images.unsplash.com/photo-1594938298603-c8148c4b4352?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Women's Handbag Leather", Price = 8900, Category = "Women's Fashion", Description = "Genuine leather, multiple compartments, adjustable strap.", ImageUrl = "https://images.unsplash.com/photo-1548036328-c9fa89d128fa?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Heels Stiletto 3-inch", Price = 4200, Category = "Women's Fashion", Description = "Pointed toe, metallic finish, cushioned insole.", ImageUrl = "https://images.unsplash.com/photo-1543163521-1bf539c55dd2?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Gold Necklace Set", Price = 12000, Category = "Women's Fashion", Description = "Kundan work, matching earrings included, Pakistani bridal style.", ImageUrl = "https://images.unsplash.com/photo-1515562141207-7a88fb7ce338?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Haier 1.5 Ton Inverter AC", Price = 95000, Category = "Home Appliances", Description = "DC inverter, WiFi control, auto-clean filter, 5-star energy rating.", ImageUrl = "https://images.unsplash.com/photo-1585771724684-38269d6639fd?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Dawlance Refrigerator 14 Cu", Price = 75000, Category = "Home Appliances", Description = "No frost, inverter compressor, glass door shelves.", ImageUrl = "https://images.unsplash.com/photo-1584568694244-14fbdf83bd30?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Kenwood Washing Machine", Price = 55000, Category = "Home Appliances", Description = "Front load, 8kg capacity, 1200 RPM, child lock.", ImageUrl = "https://images.unsplash.com/photo-1626806787461-102c1bfaaea1?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Philips Air Fryer XXL", Price = 22000, Category = "Home Appliances", Description = "6.2L capacity, Rapid Air technology, 7 presets, digital display.", ImageUrl = "https://images.unsplash.com/photo-1648462978765-dfb3a4afc8e6?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Nespresso Coffee Machine", Price = 35000, Category = "Home Appliances", Description = "19 bar pressure, 25 second heat-up, aeroccino milk frother.", ImageUrl = "https://images.unsplash.com/photo-1517668808822-9ebb02f2a0e6?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Bedding Set King Size", Price = 8500, Category = "Home & Living", Description = "1000 thread count Egyptian cotton, 6-piece set, multiple colors.", ImageUrl = "https://images.unsplash.com/photo-1522771739844-6a9f6d5f14af?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Sofa Set 5-Seater", Price = 65000, Category = "Home & Living", Description = "Velvet fabric, wooden frame, L-shaped, includes cushions.", ImageUrl = "https://images.unsplash.com/photo-1555041469-a586c61ea9bc?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Kitchen Knife Set 7-Piece", Price = 4500, Category = "Home & Living", Description = "German steel, ergonomic handles, includes wooden block.", ImageUrl = "https://images.unsplash.com/photo-1593618998160-e34014e67546?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Non-Stick Cookware Set", Price = 6800, Category = "Home & Living", Description = "5-piece set, granite coating, induction compatible, glass lids.", ImageUrl = "https://images.unsplash.com/photo-1556909114-f6e7ad7d3136?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Wall Clock Modern Design", Price = 2800, Category = "Home & Living", Description = "Silent movement, 12-inch diameter, wooden frame, minimalist.", ImageUrl = "https://images.unsplash.com/photo-1563861826100-9cb868fdbe1c?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Maybelline Fit Me Foundation", Price = 1800, Category = "Beauty", Description = "24hr wear, 40 shades, SPF 18, oil-free formula.", ImageUrl = "https://images.unsplash.com/photo-1596462502278-27bfdc403348?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "L'Oreal Paris Lipstick Set", Price = 2400, Category = "Beauty", Description = "Matte finish, 6 shades included, long-lasting 12hr wear.", ImageUrl = "https://images.unsplash.com/photo-1586495777744-4e6b21f73b7d?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Neutrogena Skincare Kit", Price = 3500, Category = "Beauty", Description = "Cleanser, toner, moisturizer, SPF 50 sunscreen bundle.", ImageUrl = "https://images.unsplash.com/photo-1556228578-8c89e6adf883?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Dyson Supersonic Hair Dryer", Price = 85000, Category = "Beauty", Description = "Fast drying, no extreme heat, 3 speeds, magnetic attachments.", ImageUrl = "https://images.unsplash.com/photo-1522338140262-f46f5913618a?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Perfume Lattafa Oud 100ml", Price = 4500, Category = "Beauty", Description = "Long lasting 24hr Arabic fragrance, oud and musk notes.", ImageUrl = "https://images.unsplash.com/photo-1541643600914-78b084683702?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Nike Running Shoes", Price = 16500, Category = "Sports", Description = "React foam midsole, breathable mesh, reflective details.", ImageUrl = "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Yoga Mat Premium", Price = 3200, Category = "Sports", Description = "6mm thickness, non-slip surface, carrying strap included.", ImageUrl = "https://images.unsplash.com/photo-1601925228787-43a3e6e84f7e?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Dumbbell Set 20kg", Price = 8500, Category = "Sports", Description = "Rubber coated, chrome handle, includes storage rack.", ImageUrl = "https://images.unsplash.com/photo-1571019613454-1cb2f99b2d8b?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Cricket Bat Kashmir Willow", Price = 4500, Category = "Sports", Description = "Full size, 6 grains, thick edges, rubber grip.", ImageUrl = "https://images.unsplash.com/photo-1531415074968-036ba1b575da?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Football Adidas Original", Price = 6500, Category = "Sports", Description = "Size 5, FIFA approved, thermally bonded panels.", ImageUrl = "https://images.unsplash.com/photo-1508098682722-e99c43a406b2?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Atomic Habits - James Clear", Price = 1800, Category = "Books", Description = "Bestseller on building good habits and breaking bad ones.", ImageUrl = "https://images.unsplash.com/photo-1544716278-ca5e3f4abd8c?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Rich Dad Poor Dad", Price = 1500, Category = "Books", Description = "Robert Kiyosaki's classic on financial education and investing.", ImageUrl = "https://images.unsplash.com/photo-1592496431122-2349e0fbc666?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "The Psychology of Money", Price = 1600, Category = "Books", Description = "Morgan Housel's guide to thinking about money and wealth.", ImageUrl = "https://images.unsplash.com/photo-1554284126-aa88f22d8b74?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Nestle Everyday Milk Powder 1kg", Price = 1200, Category = "Grocery", Description = "Full cream milk powder, rich in calcium and vitamins.", ImageUrl = "https://images.unsplash.com/photo-1550583724-b2692b85b150?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Basmati Rice 5kg Premium", Price = 2800, Category = "Grocery", Description = "Long grain, aromatic, aged for 2 years, Punjab origin.", ImageUrl = "https://images.unsplash.com/photo-1586201375761-83865001e31c?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Organic Honey 500g", Price = 1800, Category = "Grocery", Description = "Pure Sidr honey, raw unfiltered, from Balochistan mountains.", ImageUrl = "https://images.unsplash.com/photo-1587049352846-4a222e784d38?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Green Tea Box 100 Bags", Price = 950, Category = "Grocery", Description = "Antioxidant rich, Lipton premium blend, individually wrapped.", ImageUrl = "https://images.unsplash.com/photo-1564890369478-c89ca6d9cde9?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "LEGO City Police Set", Price = 8500, Category = "Toys", Description = "850 pieces, 4 minifigures, police station and cars.", ImageUrl = "https://images.unsplash.com/photo-1560807707-8cc77767d783?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Remote Control Car", Price = 3500, Category = "Toys", Description = "4WD off-road, 30km/h speed, 2.4GHz control, LED lights.", ImageUrl = "https://images.unsplash.com/photo-1594787318286-3d835c1d207f?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Barbie Dream House", Price = 12000, Category = "Toys", Description = "3-story, 8 rooms, 70+ accessories, includes doll.", ImageUrl = "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Car Dash Cam 4K", Price = 8500, Category = "Automotive", Description = "4K resolution, night vision, GPS, parking mode, loop recording.", ImageUrl = "https://images.unsplash.com/photo-1449965408869-eaa3f722e40d?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Car Vacuum Cleaner", Price = 2800, Category = "Automotive", Description = "12V DC, 120W, wet & dry, includes attachments.", ImageUrl = "https://images.unsplash.com/photo-1558317374-067fb5f30001?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Car Seat Cover Set", Price = 4500, Category = "Automotive", Description = "Leather finish, universal fit, includes headrest covers.", ImageUrl = "https://images.unsplash.com/photo-1503376780353-7e6692767b70?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Blood Pressure Monitor", Price = 6500, Category = "Health", Description = "Automatic digital, arm cuff, memory for 2 users, irregular heartbeat detection.", ImageUrl = "https://images.unsplash.com/photo-1631549916768-4119b2e5f926?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Vitamin C 1000mg 60 Tablets", Price = 1200, Category = "Health", Description = "Immune support, antioxidant, slow release formula.", ImageUrl = "https://images.unsplash.com/photo-1584308666744-24d5c474f2ae?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Digital Thermometer", Price = 850, Category = "Health", Description = "60 second reading, fever alert, memory recall, flexible tip.", ImageUrl = "https://images.unsplash.com/photo-1584982751601-97dcc096659c?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Protein Powder Whey 2kg", Price = 8500, Category = "Health", Description = "25g protein per serving, chocolate flavor, 60 servings.", ImageUrl = "https://images.unsplash.com/photo-1593095948071-474c5cc2989d?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Moleskine Notebook Classic", Price = 2800, Category = "Stationery", Description = "A5 size, hardcover, 240 pages, elastic closure, ribbon.", ImageUrl = "https://images.unsplash.com/photo-1544816155-12df9643f363?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Parker Pen Gift Set", Price = 4500, Category = "Stationery", Description = "Ballpoint + rollerball, stainless steel, gift box included.", ImageUrl = "https://images.unsplash.com/photo-1583485088034-697b5bc54ccd?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "TP-Link WiFi Router AX3000", Price = 12000, Category = "Smart Home", Description = "WiFi 6, dual band, 4 antennas, MU-MIMO, covers 2500 sqft.", ImageUrl = "https://images.unsplash.com/photo-1544197150-b99a580bb7a8?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Smart LED Bulb RGB", Price = 1200, Category = "Smart Home", Description = "WiFi controlled, 16 million colors, voice compatible, 9W.", ImageUrl = "https://images.unsplash.com/photo-1565814636199-ae8133055c1c?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Security Camera 360 WiFi", Price = 5500, Category = "Smart Home", Description = "2K resolution, night vision, two-way audio, motion detection.", ImageUrl = "https://images.unsplash.com/photo-1557597774-9d475d030a23?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Apple Watch Series 9", Price = 95000, Category = "Electronics", Description = "S9 chip, always-on display, health sensors, 18hr battery.", ImageUrl = "https://images.unsplash.com/photo-1546868871-7041f2a55e12?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Portable Power Bank 20000mAh", Price = 4500, Category = "Electronics", Description = "65W fast charging, dual USB-C, LED display, airline safe.", ImageUrl = "https://images.unsplash.com/photo-1609091839311-d5365f9ff1c5?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Mechanical Keyboard RGB", Price = 8500, Category = "Electronics", Description = "Cherry MX switches, per-key RGB, aluminum frame, USB-C.", ImageUrl = "https://images.unsplash.com/photo-1587829741301-dc798b83add3?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Gaming Mouse Logitech G502", Price = 7500, Category = "Electronics", Description = "25K DPI sensor, 11 buttons, RGB, HERO sensor, adjustable weight.", ImageUrl = "https://images.unsplash.com/photo-1527864550417-7fd91fc51a46?w=500", CreatedByEmail = "system@daraz.com" },
            new Product { Name = "Wireless Earbuds Samsung", Price = 18000, Category = "Electronics", Description = "ANC, 360 audio, 6hr + 18hr case battery, IPX7.", ImageUrl = "https://images.unsplash.com/photo-1590658268037-6bf12165a8df?w=500", CreatedByEmail = "system@daraz.com" }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}

app.Run();