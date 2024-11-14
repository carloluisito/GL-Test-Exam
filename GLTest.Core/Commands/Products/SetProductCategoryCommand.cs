using GLTest.Core.Common;
using GLTest.Core.Repositories.Categories;
using GLTest.Core.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GLTest.Core.Commands.Products
{
    public class SetProductCategoryCommand : ISetProductCategoryCommand
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetProductCategoryCommand(IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult<bool>> ExecuteAsync(Guid productId, Guid categoryId)
        {
            var product = await _productRepository.FirstOrDefaultAsync(a => a.ProductId == productId, include: p => p.Include(c => c.Categories));
            if (product == null)
                return new CommandResult<bool>("Set_Product_Category_Product_NotFound", "Product not found. ");

            var category = await _categoryRepository.FirstOrDefaultAsync(a => a.CategoryId == categoryId);
            if (category == null)
                return new CommandResult<bool>("Set_Product_Category_Category_NotFound", "Category not found. ");

            bool isAlreadyLinked = product.Categories.Any(category => category.CategoryId == categoryId);

            if (isAlreadyLinked)
                return new CommandResult<bool>("Set_Product_Category_Category_AlreadyLinked", "Category already linked in the product.");

            product.AddCategory(category);

            await _unitOfWork.CommitAsync();

            return new CommandResult<bool>(true);
        }
    }
}
