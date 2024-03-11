using System.Collections.Generic;

using ProductManagement.Models;
using ProductManagement.Repository;

namespace ProductManagement.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = new CategoryRepository();
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public List<ProductsCategory> GetProductCategoriesById(int catId)
        {
            return _categoryRepository.GetProductCategoriesById(catId);
        }
    }
}