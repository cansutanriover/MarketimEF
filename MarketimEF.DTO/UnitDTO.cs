using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.DTO
{
    public class UnitDTO:IEntity
    {
        public byte UnitId { get; set; }
        public string UnitName { get; set; }

    }
}
