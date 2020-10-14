using Joole.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Repo
{
    public class PropertyRepo: Repository<Property>
    {
        public PropertyRepo() {
            entities = db.Set<Property>();
        }
        public override Property Get(long id)
        {
            return base.Get(id);
        }
    }
}
