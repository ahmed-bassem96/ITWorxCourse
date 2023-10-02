using ITWorxCourse.DAL.Entiities;
using ITWorxCouurse.DAL.Entiities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorxCourse.BLL.Interfaces
{
    public interface ICategoryRepo
    {
        IEnumerable<Category> GetAll();

        IQueryable<Category> SearchCategoriesByName(string name);

        Category GetById(int id);

        int Add(Category category);

        int Update(Category category);

        int Delete(Category category);
    }
}
