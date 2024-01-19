using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExp.Business.Exceptions
{
    public class InvalidContenttype:Exception
    {
        private readonly string Propertyname;

        public InvalidContenttype()
        {
                
        }

        public InvalidContenttype(string? message) : base(message)
        {
        }
        public InvalidContenttype(string propertyname,string? message) : base(message)
        {
            this.Propertyname = propertyname;
        }
    }
}
