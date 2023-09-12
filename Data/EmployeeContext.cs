using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ManagementPortal.Models;

namespace ManagementPortal.Data
{
    public class EmployeeContext : IdentityDbContext<User>
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; } //CREATES THE ENTITY
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(p => p.PayRate)
                    .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Employee>()
                .Property(p => p.Hours)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>()
               .Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Department>().HasData(
               new Department { DepartmentID = "AD", DepartmentName = "Administration" },
               new Department { DepartmentID = "AC", DepartmentName = "Accounting" },
               new Department { DepartmentID = "IT", DepartmentName = "Information Technology" },
               new Department { DepartmentID = "CS", DepartmentName = "Customer Service" },
               new Department { DepartmentID = "SA", DepartmentName = "Sales" },
               new Department { DepartmentID = "OP", DepartmentName = "Operations" }
               );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Luke Skywalker",
                    StartDate = new DateTime(2010, 6, 15),
                    Title = "Human Resources Manager",
                    PayRate = 30,
                    Hours = 40,
                    DepartmentId = "AD"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Leia Organa",
                    StartDate = new DateTime(2007, 12, 17),
                    Title = "Junior Accountant",
                    PayRate = 18,
                    Hours = 40,
                    DepartmentId = "AC"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Ezra Bridger",
                    StartDate = new DateTime(2018, 9, 20),
                    Title = "Sales Associate",
                    PayRate = 22,
                    Hours = 35,
                    DepartmentId = "SA"
                }

            );
            //ADD ONE PRODUCT
            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "LightSaber",
                Description = "Laser sword useful for cutting objects",
                Inventory = 42,
                Price = 29.99M
            });
        }
    }
}
