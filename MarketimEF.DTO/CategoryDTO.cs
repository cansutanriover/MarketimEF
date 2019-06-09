using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.DTO
{
    public class CategoryDTO:IEntity
    {
        public byte CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
