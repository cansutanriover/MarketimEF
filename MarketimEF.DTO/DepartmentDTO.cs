using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.DTO
{
    public class DepartmentDTO:IEntity
    {
        public byte DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
