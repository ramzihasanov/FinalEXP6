using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExp.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
