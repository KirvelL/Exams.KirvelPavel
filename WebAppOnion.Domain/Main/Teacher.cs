using System;
using System.Collections.Generic;
using System.Text;
using WebAppOnion.Domain.Main;

namespace WebAppOnion.Domain
{
    class Teacher
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

    }
}
