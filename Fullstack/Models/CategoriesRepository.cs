using System;

namespace Fullstack.Models;

public static class CategoriesRepository
{
  private static List<Category> _categories = new List<Category>
  {
      new Category { CategoryId = 1, Name = "Electronics", Description = "Devices and gadgets" },
      new Category { CategoryId = 2, Name = "Books", Description = "Literature and educational materials" },
      new Category { CategoryId = 3, Name = "Clothing", Description = "Apparel and accessories" }
  };

  public static void AddCategory(Category category)
  {
    var maxId = _categories.Max(x => x.CategoryId);
    category.CategoryId = maxId + 1;
    _categories.Add(category);
  }

  public static List<Category> GetCategories()
  {
    return _categories;
  }

  public static Category? GetCategoryById(int id)
  {
    var category = _categories.FirstOrDefault(c => c.CategoryId == id);
    if (category != null)
    {
      return new Category
      {
        CategoryId = category.CategoryId,
        Name = category.Name,
        Description = category.Description
      };
    }
    return null;
  }

  public static void UpdateCategory(int id, Category category)
  {
    if (id != category.CategoryId)
    {
      throw new ArgumentException("Category ID mismatch");
    }

    var categoryToUpdate = _categories.FirstOrDefault(c => c.CategoryId == id);
    if (categoryToUpdate != null)
    {
      categoryToUpdate.Name = category.Name;
      categoryToUpdate.Description = category.Description;
    }
    else
    {
      throw new KeyNotFoundException("Category not found");
    }
  }


  public static void DeleteCategory(int id)
  {
    var category = _categories.FirstOrDefault(c => c.CategoryId == id);
    if (category != null)
    {
      _categories.Remove(category);
    }
    else
    {
      throw new KeyNotFoundException("Category not found");
    }
  }

}
