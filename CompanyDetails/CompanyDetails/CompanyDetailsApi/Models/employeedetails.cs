using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDetailsApi.Models
{
    public class employeedetails
    {
        public long Id { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public int EmpPhone { get; set; }

        public int DeptId { get; set; }
        public string EmpDept { get; set; }

        public int EmpSal { get; set; }
        public DateTime SalDate { get; set; }
    }
}
