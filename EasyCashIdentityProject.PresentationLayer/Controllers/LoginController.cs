using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        //SignInManager sınıfındaki AppUser sınıfına göre _signInManager field'ı oluştursun.
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        //Yapıcı metodumuzu oluşturuyoruz.
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            //false = Şifreyi hatırlanasın anlamına gelir.
            //true vermemizin nedeni ise kullanıcı her bir yanlış değer girdiğinde databasedeki AccessFaildCount değeri 1 artacak ve eğer 5 defa şifresini yanlış girdiği zaman sistemden belli bir süre engellenicek.
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, true);
            //Eğer giriş doğru yapılmışsa MyProfile sayfasına yönlendirir.
            if (result.Succeeded)
            {
                //Sisteme girilen kullanıcı adı ne ise onu döner.
                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

                //Eğer sisteme giriş yapan kullanıcı mail adresini onaylamış ise MyProfile sayfasına yönlendirecek.
                if (user.EmailConfirmed == true)
                {
                    return RedirectToAction("Index", "MyAccounts");
                }
            }
            return View();
        }
    }
}
