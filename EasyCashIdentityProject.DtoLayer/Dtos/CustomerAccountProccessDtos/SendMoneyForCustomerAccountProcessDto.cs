using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountProccessDtos
{
    public class SendMoneyForCustomerAccountProcessDto
    {

        //İşlem türü.
        public string ProcessType { get; set; }

        //Tutar
        public decimal Amount { get; set; }

        //Tarih
        public DateTime ProcessDate { get; set; }

        //Boş geçilebilir olduğu için int'in yanına ? işareti koyuyoruz.
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string ReceiverAccountNumber { get; set; }

    }
}
