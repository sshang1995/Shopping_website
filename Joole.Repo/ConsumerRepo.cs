using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Joole.Data;


namespace Joole.Repo
{
    public class ConsumerRepo: Repository<Consumer>
    {
        public ConsumerRepo()
        {
            entities = db.Set<Consumer>();
        }

     

    }
}
