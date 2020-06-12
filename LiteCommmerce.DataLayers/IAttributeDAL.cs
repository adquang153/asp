using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers
{
    public interface IAttributeDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Attributes> List();
    }
}
