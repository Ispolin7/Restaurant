using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Controllers.ViewModels;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signManager;
        public AccountController(SignInManager<IdentityUser> signManager)
        {
            _signManager = signManager;
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signManager.PasswordSignInAsync(model.Username,
                   model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {                    
                    return RedirectToAction("Index", "TableOrders");
                }
            }

            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
    }
}