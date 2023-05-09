using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Abstract
{
    //IGenericDal'dan CustomerAccount sınııfı için miras alacak.
    public interface ICustomerAccountDal:IGenericDal<CustomerAccount>
    {
    }
}
