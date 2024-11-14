using GLTest.Core.Domains.Categories;
using GLTest.Core.Domains.Products;

namespace GLTest.Core.Domains.ProductCategory
{
    public class ProductCategory
    {
        public Guid ProductId { get; private set; }
        public Product Product {get; private set;}
        public Guid CategoryId { get; private set; }
        public Category Category {get; private set;}

        protected ProductCategory() {}

        protected ProductCategory Create(Guid productId, Guid categoryId) 
        {
            return new ProductCategory
            {
                ProductId = productId,
                CategoryId = categoryId
            };
        }
    }
}