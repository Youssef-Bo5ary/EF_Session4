using DatabaseFirst.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            NorthwindDbContext dbcontext = new NorthwindDbContext();

            ///=======RUN SQL SCRIPT =========================
            //1.Execute Select Statment

            #region DQL  
            ////FromSqlRaw
            //var Categories = dbcontext.Categories.FromSqlRaw("Select * from Categories");
            //foreach (var category in Categories) Console.WriteLine(category);

            //int Count = 2;
            ////FromSqlInterpolated
            //Categories = dbcontext.Categories.FromSqlInterpolated($"select top({Count}) *from Categories"); 
            #endregion

            //2. execute with DML statment
            #region DML 
            ////ExecuteSqlRaw()
            //dbcontext.Database.ExecuteSqlRaw(" update  Categories set CategoryName = \"NewCategory\" where CategoryID = 2");
            ////ExecuteSqlInterpolated
            //dbcontext.Database.ExecuteSqlInterpolated($" update  Categories set CategoryName = \"NewCategory\" where CategoryID = 2");
            ////Interpolated => u can make interpolation (a $ sign is a must)
            #endregion

            #region LOCAL VS REMOTE  

         //   dbcontext.Products.Load();//==> Load All Products from DB to Local [Memory]
         ////===============================================================================

         //   if (dbcontext.Products.Local.Any(p => p.UnitsInStock == 0)) //===> Local
         //       Console.WriteLine("there is a products out of stock");
         //   else if (dbcontext.Products.Any(p => p.UnitsInStock == 0))//===> Remote
         //       Console.WriteLine("there is a products out of stock");
         //   else Console.WriteLine("there is no products out of stock");
         //   //=========================================================================

         //   var Result = dbcontext.Products.Find(2);// ===> will search first in Local
         //                                           // then will search remote by sending a request to DB
         //   Console.WriteLine(Result.ProductName);
            #endregion

        }
    }
}
