using Joole.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Joole.Service
{
    public interface IConsumerService
    {
    
        //Consumer GetConsumer(string Consumer_Name, string Password);
        void InsertConsumer(Consumer user);
        
    }
}
