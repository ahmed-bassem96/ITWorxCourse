using ITWorxCourse.BLL.Interfaces;
using ITWorxCourse.DAL.Entiities;
using ITWorxCouurse.DAL.Contexts;
using ITWorxCouurse.DAL.Entiities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorxCourse.BLL.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ItWorxDbContext _dbContext;

        public CategoryRepo(ItWorxDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Category category)
        {
            _dbContext.Categories.Add(category);

            return _dbContext.SaveChanges();
        }

        public int Delete(Category category)
        {
            _dbContext.Categories.Remove(category);

            return _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
           return _dbContext.Categories.Find(id);
        }

        public int Update(Category category)
        {
            _dbContext.Categories.Update(category);

            return _dbContext.SaveChanges();    
        }

        public IQueryable<Category> SearchCategoriesByName(string name)
        {
          return  _dbContext.Categories.Where(C=>C.Name.ToLower().Contains(name.ToLower()));
        }

       
    }
}
