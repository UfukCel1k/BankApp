using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Bağlantı adresi
            //server = Databasein kendi ismi
            //initial catalog = Oluşturacağımız database tablosunun ismini belirtiyoruz.
            optionsBuilder.UseSqlServer("server=LAPTOP-6TNEFTCT\\SQLEXPRESS;initial catalog=EasyCashDb;integrated Security=true");
        }

        //Veri tabanına yansıtmak istediğimiz entityleri tanımlıyoruz.
        //CustomerAccounts Sql tablosuna yansıyan tablo ismidir.
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
    }
}
