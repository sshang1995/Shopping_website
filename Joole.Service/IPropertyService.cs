using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Joole.Data;
namespace Joole.Service
{
    public interface IPropertyService
    {
        Property GetProperty(long id);
    }
}
