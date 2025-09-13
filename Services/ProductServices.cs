using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ecommerce2.console.models;

namespace Ecommerce2.console.Services
{
    public class ProductServices
    {
        private readonly List<Product> _products = new();

        public ProductServices()
        {
            // بيانات افتراضية
            _products.Add(new Product(Guid.NewGuid(), "Chocolate Cake", 15.00m, 10));
            _products.Add(new Product(Guid.NewGuid(), "Croissant", 2.50m, 50));
            _products.Add(new Product(Guid.NewGuid(), "Coffee", 3.00m, 30));
            _products.Add(new Product(Guid.NewGuid(), "Bread", 1.50m, 40));
        }

        public IEnumerable<Product> GetAll() => _products;

        // يمكن أن ترجع null، لذلك نستخدم Product?
        public Product? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);

        public Product AddProduct(string name, decimal price, int quantity)
        {
            var product = new Product(Guid.NewGuid(), name, price, quantity);
            _products.Add(product);
            return product;
        }
    }
}
    

