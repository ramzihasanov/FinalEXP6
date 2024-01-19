using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExp.Business.Exceptions
{
    public class InvalidImage:Exception
    {
        private readonly string Propertyname;

        public InvalidImage()
        {

        }

        public InvalidImage(string? message) : base(message)
        {
        }
        public InvalidImage(string propertyname, string? message) : base(message)
        {
            this.Propertyname = propertyname;
        }
    }
}
