using EF_Session4.Contexts;
using EF_Session4.Entity;
using EF_Session4.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Net.Cache;

namespace EF_Session4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (OfficeDbContext officeDb = new OfficeDbContext())
            {
                
                Employee emp01 = new Employee()
                {
                    Name = "ALi",
                    Salary = 1000,
                    Age = 20,
                    DeptId = 23

                };
                Employee emp02 = new Employee()
                {
                    Name = "Amr",
                    Salary = 2000,
                    Age = 21,
                    DeptId = 23

                };
                Employee emp03 = new Employee()
                {
                    Name = "Aya",
                    Salary = 1000,
                    Age = 20,
                    DeptId = 24

                };
                Employee emp04 = new Employee()
                {
                    Name = "Ahmed",
                    Salary = 11000,
                    Age = 25,
                    DeptId = 26

                };
                Employee emp05 = new Employee()
                {
                    Name = "Mohamed Hegazy",
                    Salary = 12000,
                    Age = 26,
                    DeptId = 26

                };
                Employee emp06 = new Employee()
                {
                    Name = "Saied Ahmed",
                    Salary = 13000,
                    Age = 27,
                    DeptId = 26

                };
                Employee emp07 = new Employee()
                {
                    Name = "youssef zaher",
                    Salary = 20000,
                    Age = 28,
                    DeptId = 26

                };


                Department dep01 = new Department()
                {
                    
                    Name = "Maths",
                    DateOfCreation = DateTime.Now

                };
                Department dep02 = new Department()
                {

                    Name = "Science",
                    DateOfCreation = DateTime.UtcNow

                };
                Department dep03 = new Department()
                {

                    Name = "Financial",
                    DateOfCreation = DateTime.Now

                };
                Department dep04 = new Department()
                {

                    Name = "Mechanic",
                    DateOfCreation = DateTime.Today

                };

                #region Insert
                // Console.WriteLine(officeDb.Entry(emp01).State);
                // // Console.WriteLine(officeDb.Entry(dep01).State);

                // //officeDb.Add(emp01);
                // // officeDb.Add(emp02);
                // // officeDb.Add(emp03);
                // //officeDb.Add(dep01);
                // // officeDb.Add(dep02);
                // //officeDb.Add(dep03);
                // // officeDb.Add(dep04);
                // officeDb.Add(emp04);
                // officeDb.Add(emp05);
                // officeDb.Add(emp06);
                // officeDb.Add(emp07);

                // Console.WriteLine(officeDb.Entry(emp01).State);
                //// Console.WriteLine(officeDb.Entry(dep01).State);

                // officeDb.SaveChanges(); 
                #endregion

                #region join OPerator 

                //Query Syntax
                #region general join  
                //var Result = from E in officeDb.Employees
                //              join D in officeDb.Departments
                //              on E.DeptId equals D.DepId  // general join
                //              select new // I put a condition on what I need to print only
                //              {
                //                Name = E.Name,
                //                DeptName =D.Name
                //              };
                //foreach (var item in Result) Console.WriteLine(item); 
                #endregion


                #region join using where  
                //var Result01 = from E in officeDb.Employees
                //             join D in officeDb.Departments
                //             on E.DeptId equals D.DepId
                //             where E.Salary > 10000
                //             select new // I put a condition on what I need to print only
                //             {
                //                 Name = E.Name,
                //                 DeptName = D.Name,
                //                 Salary = E.Salary
                //             };
                //foreach (var item in Result01) Console.WriteLine(item); 
                #endregion

                //fluent Syntax
                #region general join  
                //var Result = officeDb.Employees.Join(officeDb.Departments, E => E.DeptId, D => D.DepId , (E, D) => new 
                //{
                //Name = E.Name,
                //DeptName =D.Name
                //});
                //foreach(var item in Result) Console.WriteLine(item); 
                #endregion

                #region join using where     
                //var Result = officeDb.Employees.Join(officeDb.Departments, E => E.DeptId, D => D.DepId, (E, D) => new
                //{
                //    Name = E.Name,
                //    DeptName = D.Name,
                //    Salary = E.Salary
                //}).Where(A=> A.Salary>11000);
                //foreach (var result in Result) Console.WriteLine(result); 
                #endregion

                #endregion

                #region Mapping View
                // var Result = officeDb.Employees.FromSqlRaw("select *\r\nfrom EmployeeDepView");

                //OR
                //foreach (var item in officeDb.EmployeeDepViews)
                //{
                //    Console.WriteLine($"{item.EmployeeName}::{item.DepartmentName}");
                //}


                #endregion

                #region Tracker 
                #region Tracking  
                //var Employee = (from E in officeDb.Employees
                //               where E.ID == 14
                //               select E).FirstOrDefault();
                //Console.WriteLine(officeDb.Entry(Employee).State);//unchanged
                //Employee.Name = "Hamada";
                //Console.WriteLine(officeDb.Entry(Employee).State);//Modified
                //officeDb.SaveChanges();
                //Console.WriteLine(officeDb.Entry(Employee).State);//Modified
                //////who change the state the change tracker
                #endregion

                #region no tracking  
                //var Employee = (from E in officeDb.Employees
                //                  where E.ID == 14
                //                  select E).AsNoTracking().FirstOrDefault();//will not track or save changes
                //Console.WriteLine(officeDb.Entry(Employee).State);//detached
                //Employee.Name = "mona";
                //Console.WriteLine(officeDb.Entry(Employee).State);//Detached
                //officeDb.SaveChanges();
                //Console.WriteLine(officeDb.Entry(Employee).State);//Detached
                ////always Detached as not tracking the changes
                #endregion


                #endregion

                #region MaxBY , MinBY  
                //EX.
                //Employee[] employees =
                //{
                //new Employee() {ID=1 , Name="Omar", Age=20 , Salary = 1000 , DeptId = 26 },
                //new Employee() {ID=2 ,Name="Tamer",Age=21 , Salary=2000 , DeptId = 26 },
                //new Employee(){ID=3 , Name="Hany" , Age=22 , Salary= 3000 , DeptId=25 }
                //};

                #region ICompareable  
                //var MaxEmployee = employees.Max(); // in employee class make it
                //                                   // implement ICompareable and compares based on Salary
                //var MinEmployee = employees.Min();
                //Console.WriteLine($"Max = {MaxEmployee?.Name ?? "not found"}");//will get the name with max salary
                //Console.WriteLine($"Min = {MinEmployee?.Name}");//get name with min salary 
                #endregion

                //OR
                #region OrderBy  
                //var MaxEmp = employees.OrderByDescending( x => x.Salary ).First();
                //var MinEmp = employees.OrderBy(x => x.Salary).First();
                //Console.WriteLine($"Max = {MaxEmp?.Name}");//will get the name with max salary
                //Console.WriteLine($"Min = {MinEmp?.Name}"); 
                #endregion

                #region MaxBy , MinBy (LinQ Operators)        
                //var MaxEmp = employees.MaxBy(e => e.Salary);
                // var MinEmp = employees.MinBy(e => e.Salary);
                // Console.WriteLine($"Max = {MaxEmp?.Name}");//will get the name with max salary
                // Console.WriteLine($"Min = {MinEmp?.Name}");  
                #endregion
                #endregion

                #region DataBase First 

                #endregion
            }

        }
    }
}
