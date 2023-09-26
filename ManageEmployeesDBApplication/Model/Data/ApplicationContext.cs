using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ManageEmployeesDBApplication.Model.Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=ManageEmployeesDBApplicationDB;Trusted_Connection=True;");

        }
    }
}
