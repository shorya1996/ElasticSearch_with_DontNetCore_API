using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyDetailsConsoleApp
{
    
    class employeedetail
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public int EmpPhone { get; set; }

        public int DeptId { get; set; }
        public string EmpDept { get; set; }

        public int EmpSal { get; set; }
        public DateTime SalDate { get; set; }
        public string LastName { get; set; }
    }
}
