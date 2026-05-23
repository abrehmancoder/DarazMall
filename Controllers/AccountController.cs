using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // AUTO-LOGIN FUNCTIONALITY ADDED
        [HttpPost]
        public async Task<IActionResult> Register(string fullName, string email, string password, string role)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Email and Password are required fields.");
                return View();
            }

            string cleanEmail = email.Trim().ToLower();
            string cleanPassword = password; // Strict preservation of raw strings (keeps special symbols like & intact)

            var userExists = await _context.Users.AnyAsync(u => u.Email.ToLower() == cleanEmail);
            if (userExists)
            {
                ModelState.AddModelError("", "This email is already registered.");
                return View();
            }

            var newUser = new User
            {
                FullName = string.IsNullOrEmpty(fullName) ? "Regular User" : fullName.Trim(),
                Email = cleanEmail,
                Password = cleanPassword,
                Role = string.IsNullOrEmpty(role) ? "Customer" : role.Trim()
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            // =================================================================
            // AUTOMATIC LOGIN SYSTEM ON SIGNUP (Bypasses manual login step)
            // =================================================================
            HttpContext.Session.Clear();
            HttpContext.Session.SetString("UserEmail", newUser.Email.ToLower().Trim());
            HttpContext.Session.SetString("UserName", newUser.FullName);
            HttpContext.Session.SetString("UserRole", newUser.Role);

            TempData["CartMessage"] = $"Welcome {newUser.FullName}! Your account has been created and logged in automatically.";

            if (newUser.Role == "Admin")
            {
                return Redirect("/Products/Index");
            }
            return Redirect("/Products/Shop");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Please fill both Email and Password fields.");
                return View();
            }

            string cleanEmail = email.Trim().ToLower();
            string cleanPassword = password; // Raw match check for complex special character string lengths

            var matchedUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == cleanEmail && u.Password == cleanPassword);

            if (matchedUser != null)
            {
                HttpContext.Session.Clear();

                HttpContext.Session.SetString("UserEmail", matchedUser.Email.ToLower().Trim());
                HttpContext.Session.SetString("UserName", matchedUser.FullName);
                HttpContext.Session.SetString("UserRole", matchedUser.Role);

                if (matchedUser.Role == "Admin")
                {
                    return Redirect("/Products/Index");
                }

                return Redirect("/Products/Shop");
            }

            ModelState.AddModelError("", "Invalid Email Address or Password!");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Products/Shop");
        }
    }
}