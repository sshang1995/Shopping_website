using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.Data;
using Joole.Repo;

namespace Joole.Service
{
    public class ProductService : IProductService
    {

        private ProductRepo productRepository = new ProductRepo();
       
        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll();
            
        }

        public Product GetProduct(long id)
        {
            return productRepository.Get(id);
        }

        public void InsertProduct(Product product)
        {
            productRepository.Insert(product);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.Update(product);
        }

        public void DeleteProduct(long id)
        {
            Product product = productRepository.Get(id);
            productRepository.Remove(product);
            productRepository.SaveChanges();
        }

    }
}
