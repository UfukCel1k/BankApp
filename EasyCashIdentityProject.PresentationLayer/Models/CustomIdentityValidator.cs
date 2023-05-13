using Microsoft.AspNetCore.Identity;

namespace EasyCashIdentityProject.PresentationLayer.Models
{
    public class CustomIdentityValidator : IdentityErrorDescriber
    {
        //Override metodun işleyişi aynı şekilde bırakır ama içeriği bizim istediğimiz formata çeviriyor.
        //PasswordTooShort şifrenin çok kısa olduğunu bildiren metodtur.
        public override IdentityError PasswordTooShort(int length)
        {
            //PasswordTooShort metoduyla karşılaştığımız zaman Description bölümündeki hatayı yansıtacak.
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola en az {length} karakter olmalıdır"
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lütfen en az 1 büyük harf giriniz"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen en az 1 küçük harf giriniz"
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Lütfen en az 1 tane rakam giriniz"
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Lütfen en az 1 tane sembol giriniz"
            };
        }
    }
}
