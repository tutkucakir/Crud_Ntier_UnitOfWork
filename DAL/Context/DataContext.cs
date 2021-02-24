using MODEL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class DataContext:DbContext
    {
        public DataContext()
        {
            Database.Connection.ConnectionString = @"Server=.; database=SampleCrud; uid=sa; pwd=1";
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Optional
            base.OnModelCreating(modelBuilder);
        }

    }
}
