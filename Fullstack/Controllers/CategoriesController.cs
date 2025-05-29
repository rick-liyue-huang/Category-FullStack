using Fullstack.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fullstack.Controllers
{
  public class CategoriesController : Controller
  {
    // GET: CategoryController
    public IActionResult Index()
    {
      var categories = CategoriesRepository.GetCategories();
      return View(categories);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
      var category = id.HasValue ? CategoriesRepository.GetCategoryById(id.Value) : new Category();
      if (category == null)
      {
        return NotFound();
      }
      return View(category);
    }


    [HttpPost]
    public IActionResult Edit(Category category)
    {
      CategoriesRepository.UpdateCategory(category.CategoryId, category);
      return RedirectToAction(nameof(Index));
    }
  }
}
