using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.DTO
{
    public class TownDTO:IEntity
    {
        public int TownID { get; set; }
        public string TownName { get; set; }
        public int CityID { get; set; }

        public string CityName { get; set; }
    }
}
