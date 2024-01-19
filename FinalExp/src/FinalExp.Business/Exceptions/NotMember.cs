﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExp.Business.Exceptions
{
    public class NotMember:Exception
    {
        private readonly string Propertyname;

        public NotMember()
        {

        }

        public NotMember(string? message) : base(message)
        {
        }
        public NotMember(string propertyname, string? message) : base(message)
        {
            this.Propertyname = propertyname;
        }
    }
}
