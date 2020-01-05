using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDetailsApi.Models
{
    public class employeeautosuggest
    {

        public int Id { get; set; }
        public string EmpName { get; set; }

        public int DeptId { get; set; }
        public int EmpPhone { get; set; }

        public string EmpDept { get; set; }

        public int EmpSal { get; set; }
    }
}
