using ITWorxCourse.BLL.Interfaces;
using ITWorxCourse.BLL.Repositories;
using ITWorxCourse.DAL.Entiities;
using ITWorxCouurse.DAL.Entiities;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace ITWorxCourse.PL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;
        public ProductController(IProductRepo productRepo, ICategoryRepo categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index(string SearchValue,int? page)
        {
            IEnumerable<Products> products;
            
            if (string.IsNullOrEmpty(SearchValue))
            {
                products = _productRepo.GetAll().ToPagedList(page??1,3);
               
                return View(products);

            }
            else
            {
                products =_productRepo.SearchProductsByName(SearchValue).ToPagedList(page ?? 1, 3);
                return View(products);

            }
         
            
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var categories = _categoryRepo.GetAll();

            ViewBag.Category = categories;

            return Details(id, "Edit");

        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int id, Products products)
        {
            if (id != products.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productRepo.Update(products);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }

            return View(products);

        }
        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return BadRequest();
            var Product = _productRepo.GetById(id.Value);
            if (Product is null)
                return NotFound();

            return View(Product);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int? id, Products products)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var Products = _productRepo.Delete(products);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Add()
        {
            var categories = _categoryRepo.GetAll();

            ViewBag.Category = categories;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Products products)
        {
            var categories = _categoryRepo.GetAll();

            ViewBag.Category = categories;


            if (ModelState.IsValid)
            {
                var xx = _productRepo.Add(products);

                return RedirectToAction("Index");
            }
            return View(products);
            
        }
        
    }
}
