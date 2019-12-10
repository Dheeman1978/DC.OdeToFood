using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options)
            : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }













    /*PS D:\Dheeman\Personal\DOTNETCORE\Dev\OdeToFood\OdeToFood.Data> dotnet ef dbcontext list

       OdeToFood.Data.OdeToFoodDbContext
   Now go to the folder which connects to DB context with a real DB Connection string.

   PS D:\Dheeman\Personal\DOTNETCORE\Dev\OdeToFood\OdeToFood.Data> dotnet ef dbcontext info -s ..\OdeToFood\OdeToFood.csproj

   PS D:\Dheeman\Personal\DOTNETCORE\Dev\OdeToFood\OdeToFood.Data> dotnet ef migrations add initialcreate -s ..\OdeToFood\OdeToFood.csproj

   info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
         Entity Framework Core 2.2.6-servicing-10079 initialized 'OdeToFoodDbContext' using provider 'Microsoft.EntityFrameworkCore.SqlServer' with options: MaxPoolSize=128
   Done.To undo this action, use 'ef migrations remove'
   PS D:\Dheeman\Personal\DOTNETCORE\Dev\OdeToFood\OdeToFood.Data>

       dotnet ef database update -s ..\OdeToFood\OdeToFood.csproj
   */
}
