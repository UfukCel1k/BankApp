using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //AppUserRegisterDto kullanıyoruz çünkü sadece oradaki değerleri kullanıcaz.
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            Random random = new Random();
            int code;
            code = random.Next(100000, 1000000);
            //FluentValidation kontrollerden hatasız geçtiği zaman aşağıdaki if bloğuna girecek.
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "aaaa",
                    District = "bbbb",
                    ImageUrl = "cccc",
                    ConfirmCode = code

                };
                //CreateAsync = Identity için veri eklemeye yarar.
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    //Mailin kimden gideceğini gösterecek, Mailin gönderen kişinin mail adresi
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "ufukcelik.dev@gmail.com");
                    //Mailin kimden olduğunu belirtiyoruz.
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                    //mailboxAddressFrom nesne örneğinden gelen değerden gidecek
                    mimeMessage.From.Add(mailboxAddressFrom);
                    //mailboxAddressTo nesne örneğinden giden adrese gidecek
                    mimeMessage.To.Add(mailboxAddressTo);

                    //içeriği
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemi gerçekleştirmek için onay kodunuz: " + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Easy Cash Onay Kodu";

                    //Mail transfer protokol smtp.gamil.com olarak belitiyoruz. Türkiyenin port numarası 587'dir. Güvenlik sağlaması için false veriyoruz.
                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("ufukcelik.dev@gmail.com", "fbavsfldugraalni");
                    client.Send(mimeMessage);
                    client.Disconnect(true);


                    return RedirectToAction("Index", "ConfirmMail");
                }
                //Kullanıcı şifresini formatam uygun olmadığı taktirde aşağıdaki else blloğuna girer ve hata mesajını yayınlar
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
