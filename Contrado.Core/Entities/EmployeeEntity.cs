using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrado.Core.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        public string Emp_Tag { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }
        public byte Designation { get; set; }
    }
}
