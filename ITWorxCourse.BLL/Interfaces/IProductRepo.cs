using ITWorxCourse.DAL.Entiities;
using ITWorxCouurse.DAL.Entiities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorxCourse.BLL.Interfaces
{
    public interface IProductRepo
    {

        IEnumerable<Products> GetAll();
        IQueryable<Products> SearchProductsByName(string name);
        Products GetById(int id);

        int Add(Products product);

        int Update(Products product);

        int Delete(Products product);
    }
}
