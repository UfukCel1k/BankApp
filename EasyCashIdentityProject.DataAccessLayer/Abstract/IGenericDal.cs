using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Abstract
{
    //Dışarıdan T değeri alacak ve bu T değeri class olucak
    public interface IGenericDal<T> where T : class
    {
        void Insert(T t);

        void Delete(T t);

        void Update(T t);

        T GetByID(int id);

        List<T> GetList();
    }
}
