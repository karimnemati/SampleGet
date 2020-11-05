using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using DataLayer.Entities;
namespace DataLayer.Context
{
    public class Context_db: DbContext
    {

   public Context_db(DbContextOptions<Context_db> options) : base(options)
        {

        }

        public DbSet<Tbl_User> Tbl_Users { get; set; }
        



 public class ToDoContextFactory : IDesignTimeDbContextFactory<Context_db>
    {
        public Context_db CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Context_db>();
            //   builder.UseSqlServer("Data Source=.;initial Catalog=monojobs;integrated Security=SSPI;MultipleActiveResultSets=true");
            builder.UseSqlServer("Data Source=.;initial Catalog=Sample_db;integrated Security=SSPI;MultipleActiveResultSets=true");
            return new Context_db(builder.Options);
        }
    }



    }
}