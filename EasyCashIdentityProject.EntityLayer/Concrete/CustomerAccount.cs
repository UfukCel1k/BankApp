using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        public int CustomerAccountID { get; set; }

        //Hesap numarası.
        public string CustomerAccountNumber { get; set; }

        // Hesabın döviz türü.
        public string CustomerAccountCurrency { get; set; }

        //Müşterinin hesabında toplamda ne kadar bakiye var olduğunu gösterir.
        public decimal CustomerAccountBalance { get; set; }

        //Banka şubesi.
        public string BankBranch { get; set; }

        //Bu hesabın hangi kullanıcıya ait olduğunu belirtir.
        public int AppUserID { get; set; }

        public AppUser AppUser { get; set; }

    }
}
