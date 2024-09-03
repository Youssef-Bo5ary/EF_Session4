using EF_Session4.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Session4.Contexts
{
    internal class OfficeDbContext : DbContext

    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDepView>().ToView("EmployeeDepView").HasNoKey();
            modelBuilder.Entity<Department>().HasMany(D => D.Employees)
                                                  .WithOne(E => E.Department)
                                                  .IsRequired(true)
                                                  .HasForeignKey(E => E.DeptId)  //=> this the new attribute I created to be the forein key
                                                  .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Department>().HasKey(D => D.DepId);
            modelBuilder.Entity<Department>().Property(nameof(Department.DepId)).UseIdentityColumn(10, 10);
            

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = . ; DataBase = Office ; Trusted_Connection = true ; Encrypt = False");//connection;
        }

       public DbSet<Employee> Employees { get; set; }
       public DbSet<Department> Departments { get; set; }
       public DbSet<EmployeeDepView> EmployeeDepViews { get; set; }
    }
}
