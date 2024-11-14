using GLTest.Core.Domains.Products;

namespace GLTest.Core.Domains.Categories
{
    public class Category
    {
        public Guid CategoryId { get; private set; }
        public string CategoryName { get; private set; }

        public List<Product> Products { get; private set; }

        protected Category() { }

        protected Category Create(string categoryName)
        {
            return new Category
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = categoryName
            };
        }
    }
}
