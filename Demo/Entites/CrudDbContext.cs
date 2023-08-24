using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using Demo.Entites;

namespace Demo.Entites
{
    public class CrudDbContext : DbContext
    {
        //internal object Admin;
        //internal object AdminEntitys;

        public CrudDbContext(DbContextOptions<CrudDbContext> options) : base(options)
        {

        }
        //Entity sets
        public DbSet<CrudEntity> CrudEntity { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=WINDOWS-BVQNF6J;database=CrudDb;trusted_connection=true;encrypt=false");
        }



        //internal void SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}
    }


}
