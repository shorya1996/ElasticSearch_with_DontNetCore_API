using Nest;
using Newtonsoft.Json;
using System;
using System.Linq;
namespace CompanyDetailsConsoleApp
{
    class Program
    {
        private static CompanyDetailsContext dbContext = new CompanyDetailsContext();
        
        static void Main(string[] args)
        {

            Program p = new Program();
            p.GenerateIndexForEmployeeDetail();
            p.GenerateIndexForEmployeeAutoSuggest();

            Console.ReadKey();
                    }

        public void GenerateIndexForEmployeeAutoSuggest()
        {
            var result1 = (from d in dbContext.Department
                           join e in dbContext.Employee
                           on d.DeptId equals e.DeptId
                           join s in dbContext.Salary
                           on e.EmpId equals s.EmpId
                           select new employeeautosuggest
                           {

                               Id = e.EmpId,
                               EmpName = e.EmpFname,
                               DeptId = d.DeptId,
                               EmpPhone = e.EmpPhone,
                               EmpDept = d.DeptName,
                               EmpSal = s.SalaryAmount



                           }).ToList();
            Console.WriteLine(result1);
            Console.ReadLine();
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                 .DefaultIndex("employeeautosuggest");
            var client = new ElasticClient(settings);
            BulkResponse indexManyResponse = client.IndexMany(result1);
            var responseJson = result1.ToList();
            var json = JsonConvert.SerializeObject(responseJson);
            Console.WriteLine(json);
            Console.ReadLine();
        }
        public void GenerateIndexForEmployeeDetail()
        {
            var result = (from d in dbContext.Department
                          join e in dbContext.Employee
                          on d.DeptId equals e.DeptId
                          join s in dbContext.Salary
                          on e.EmpId equals s.EmpId
                          select new employeedetail
                          {

                              Id = e.EmpId,
                              EmpName = e.EmpFname,
                              EmpEmail = e.EmpEmail,
                              EmpPhone = e.EmpPhone,
                              DeptId = d.DeptId,
                              EmpDept = d.DeptName,
                              EmpSal = s.SalaryAmount,
                              SalDate = s.SalaryDate,
                              LastName=e.EmpLname

                          }).ToList();
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                 .DefaultIndex("employeedetails");
            var client = new ElasticClient(settings);
            var indexManyResponse = client.IndexMany(result);

        }
    }
}
