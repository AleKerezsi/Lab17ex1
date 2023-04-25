using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab17ex1.Models
{
    internal class MagazinDbContext : DbContext
    {
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Categorie> Categorii { get; set; }
        public DbSet<Eticheta> Etichete { get; set; }
        public DbSet<Producator> Producatori { get; set; }


        public MagazinDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Alexandra\\source\\repos\\Lab17ex1\\Lab17ex1\\MagazinDb.mdf;Integrated Security=True");
        }
    }
}
