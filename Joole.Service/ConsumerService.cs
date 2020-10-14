using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.Data;
using Joole.Repo;

namespace Joole.Service
{
    public class ConsumerService: IConsumerService
    {
        private ConsumerRepo consumerRepository = new ConsumerRepo();

        //public Consumer GetConsumer(string Consumer_Name, string Password) 
        //{
        //    return consumerRepository.Get(Consumer_Name, Password)
        //};
        public void InsertConsumer(Consumer consumer)
        {
            consumerRepository.Insert(consumer);
        }

    }
}
