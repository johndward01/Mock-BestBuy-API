using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mock_BestBuy_API
{
    public interface IDapperRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProduct(int id);
        public void InsertProduct(Product prod);
        public void UpdateProduct(Product prod);
        public void DeleteProduct(Product prod);

    }
}
