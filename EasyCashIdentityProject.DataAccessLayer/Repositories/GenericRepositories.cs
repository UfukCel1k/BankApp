using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Repositories
{
    //Dışarıdan T değeri alıcak ve aynı zamanda IGenericDal'dam miras alacak. Bu T değeri bir class olucak.
    //IGenericDal'ı implement ediyoruz.
    public class GenericRepositories<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            //Context sınıfından bir nesne türettik.
            using var context = new Context();
            //Yukarıdan T 'ye göre getir bu bu t değeri ne ise o t değerine göre silme işlemini gerçekleştir. 
            context.Set<T>().Remove(t);
            //Değişiklikleri kaydet.
            context.SaveChanges();
        }

        public T GetByID(int id)
        {
            //Context sınıfından bir nesne türettik.
            using var context = new Context();
            //ID'ye göre getirecek.
            return context.Set<T>().Find(id); 
        }
        public List<T> GetList()
        {
            //Context sınıfından bir nesne türettik.
            using var context = new Context();
            //Bütün değerleri getiricek.
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            //Context sınıfından bir nesne türettik.
            using var context = new Context();
            //t den gelen değeri eklicek.
            context.Set<T>().Add(t);
            //Değişiklikleri kaydet.
            context.SaveChanges();
        }

        public void Update(T t)
        {
            //Context sınıfından bir nesne türettik.
            using var context = new Context();
            //t den gelen değeri güncelle
            context.Set<T>().Update(t);
            //Değişiklikleri kaydet.
            context.SaveChanges();

        }
    }
}
