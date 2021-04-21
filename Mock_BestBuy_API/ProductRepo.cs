using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mock_BestBuy_API
{
    public class ProductRepo : IProductRepo
    {
        private readonly IDbConnection _connection;

        public ProductRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _connection.Query<Product>("SELECT * FROM bestbuy.products;");
        }

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("SELECT * FROM bestbuy.products WHERE ProductID = @id;", new { id = id });
        }

        public void InsertProduct(Product prod)
        {
            _connection.Execute("INSERT INTO bestbuy.products (Name, Price, CategoryID, OnSale, StockLevel) " +
                "VALUES ( @name, @price, @categoryID, @onSale, @stockLevel);",
                                                                              new { name = prod.Name,
                                                                                    price = prod.Price,
                                                                                    categoryID = prod.CategoryID,
                                                                                    onSale = prod.OnSale,
                                                                                    stockLevel = prod.StockLevel
                                                                              });
        }

        public void UpdateProduct(Product prod)
        {
            _connection.Execute("UPDATE bestbuy.products SET Name = @name, Price = @price, OnSale = @onSale, StockLevel = @stockLevel WHERE ProductID = @id",
                new {name = prod.Name, price = prod.Price, onSale = prod.OnSale, stockLevel = prod.StockLevel, id = prod.ProductID });
        }

        public void DeleteProduct(Product prod) 
        {
            _connection.Execute("DELETE from bestbuy.products WHERE ProductID = @id", new { id = prod.ProductID});
            _connection.Execute("DELETE from bestbuy.reviews WHERE ProductID = @id", new { id = prod.ProductID});
            _connection.Execute("DELETE from bestbuy.sales WHERE ProductID = @id", new { id = prod.ProductID});
        }
    }
}
