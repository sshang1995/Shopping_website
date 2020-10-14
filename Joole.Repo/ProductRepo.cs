using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.Data;
namespace Joole.Repo
{
    public class ProductRepo: Repository<Product>
    {
        public ProductRepo() {
            entities = db.Set<Product>();
        }

        public override IEnumerable<Product> GetAll()
        {
            return entities.Include("Manufacturer").Include("SubCategory").Include("PropertyValue");

        }
    }
}
