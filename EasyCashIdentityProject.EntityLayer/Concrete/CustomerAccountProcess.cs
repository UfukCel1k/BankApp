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

    }
}
