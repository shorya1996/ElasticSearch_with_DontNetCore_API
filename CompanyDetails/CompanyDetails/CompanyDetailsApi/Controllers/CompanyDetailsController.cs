using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyDetailsApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDetailsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyDetailsController : ControllerBase
    {
        private readonly ICompanyRepository _CompanyRepository;
        public CompanyDetailsController(ICompanyRepository companyRepository)
        {
            this._CompanyRepository = companyRepository;
        }

        [HttpPost]
        public IActionResult GetById([FromQuery] long EmployeeId)
        {
            var response = this._CompanyRepository.GetEmployeesById(EmployeeId);
            return Ok(response);
        }
    }
}