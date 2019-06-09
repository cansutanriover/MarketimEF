using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.DTO
{
    public class PositionDTO:IEntity
    {
        public short PositionId { get; set; }
        public string PositionName { get; set; }
        public byte DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}
