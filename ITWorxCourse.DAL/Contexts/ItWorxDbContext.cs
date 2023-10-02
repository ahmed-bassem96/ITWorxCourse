using ITWorxCourse.DAL.Entiities;
using ITWorxCouurse.DAL.Entiities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorxCouurse.DAL.Contexts
{
    public class ItWorxDbContext:DbContext
    {

        public ItWorxDbContext(DbContextOptions<ItWorxDbContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
