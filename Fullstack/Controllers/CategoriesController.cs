using Fullstack.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fullstack.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: CategoryController
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
          if (id.HasValue)
          {
              // return new ContentResult {Content = id.ToString()};
              var category = new Category
              {
                  CategoryId = id.HasValue ? id.Value : 0,
              };
              return View(category);
          }
          else
          {
              return new ContentResult {Content = "No ID provided"};
          }
          
        }

    }
}
