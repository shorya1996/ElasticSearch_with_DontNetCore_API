using CompanyDetailsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDetailsApi.Repositories
{
    public interface ICompanyRepository
    {
        string GetEmployeesById(long? EmployeeId);

    }
}
