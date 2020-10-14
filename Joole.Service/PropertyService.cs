using Joole.Data;
using Joole.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service
{
    public class PropertyService : IPropertyService
    {
        private PropertyRepo propertyRepo = new PropertyRepo();
        public Property GetProperty(long id)
        {
            return propertyRepo.Get(id);
        }
    }
}
