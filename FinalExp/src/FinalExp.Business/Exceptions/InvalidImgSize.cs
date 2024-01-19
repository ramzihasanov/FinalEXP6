using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExp.Business.Exceptions
{
    public class InvalidImgSize:Exception
    {
        private readonly string Propertyname;

        public InvalidImgSize()
        {

        }

        public InvalidImgSize(string? message) : base(message)
        {
        }
        public InvalidImgSize(string propertyname, string? message) : base(message)
        {
            this.Propertyname = propertyname;
        }
    }
}
