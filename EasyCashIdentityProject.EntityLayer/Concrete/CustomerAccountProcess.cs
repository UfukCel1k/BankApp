using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccountProcess
    {
        public int CustomerAccountProcessID { get; set; }

        //İşlem türü.
        public string ProcessType { get; set; }

        //Tutar
        public decimal Amount { get; set; }

        //Tarih
        public DateTime ProcessDate { get; set; }

        //Boş geçilebilir olduğu için int'in yanına ? işareti koyuyoruz.
        public int? SenderID { get; set; }

        public int? ReceiverID { get; set; }

        public string Description { get; set; }


        public CustomerAccount SenderCustomer { get; set; }
        public CustomerAccount ReceiverCustomer { get; set; }
    }
}
