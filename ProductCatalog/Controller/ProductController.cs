using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductCatalog.Model.Entity;
using ProductCatalog.Model.Repository;

namespace ProductCatalog.Controller
{
    public class ProductController
    {
        private ProductRestApiRepository _repository;

        public ProductController()
        {
            _repository = new ProductRestApiRepository();
        }

        public List<Product> ReadAll()
        {
            List<Product> list = new List<Product>();
            try
            {
                list = _repository.ReadAll();
            }
            catch { }
            return list;
        }

        public List<Product> ReadByProductName(string productName)
        {
            List<Product> list = new List<Product>();
            try
            {
                list = _repository.ReadByProductName(productName);
            }
            catch { }
            return list;
        }

        public List<Product> ReadByCategory(string category)
        {
            List<Product> list = new List<Product>();
            try
            {
                list = _repository.ReadByCategory(category);
            }
            catch { }
            return list;
        }

        public Product ReadByProductId(string productId)
        {
            Product product = new Product();
            try
            {
                product = _repository.ReadByProductId(productId);
            }
            catch { }
            return product;
        }
    }
}
