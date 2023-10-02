using ITWorxCourse.BLL.Interfaces;
using ITWorxCourse.DAL.Entiities;
using ITWorxCouurse.DAL.Contexts;
using ITWorxCouurse.DAL.Entiities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorxCourse.BLL.Repositories
{
    public class ProductRepo:IProductRepo
    {
        private readonly ItWorxDbContext _dbContext;
        public ProductRepo(ItWorxDbContext dbContext)
        {
            _dbContext= dbContext;
        }

        public int Add(Products product)
        {
             _dbContext.Products.Add(product);
            return _dbContext.SaveChanges();
              
        }

        public int Delete(Products product)
        {
           _dbContext.Products.Remove(product);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Products> GetAll()
        {
            return  _dbContext.Products.Include(E=>E.Category).ToList();
        }

        public Products? GetById(int id)
        {
            return _dbContext.Products.Find(id);
        }

       

        public int Update(Products product)
        {
            _dbContext.Products.Update(product);

            return _dbContext.SaveChanges();
        }

       IQueryable<Products> IProductRepo.SearchProductsByName(string name)
        {
            return _dbContext.Products.Where(P => P.Name.ToLower().Contains(name.ToLower()));
        }

    }
}
