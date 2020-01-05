using CompanyDetailsApi.Models;
using Nest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDetailsApi.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public string GetEmployeesById(long? EmployeeId)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
   .DefaultIndex("employeedetails");
            var client = new ElasticClient(settings);

            //Simple match all documents search query
            var searchResponse = client.Search<employeedetails>(s => s
      .Query(q => q
                .Term(c => c
                    .Boost(1.1)
                    .Field(p => p.Id)
                    .Value(EmployeeId)
                )
                      )
                  );
            var success = searchResponse.Documents;
            var responseJson = searchResponse.Documents;
            var json = JsonConvert.SerializeObject(responseJson);
            return json;
        }
    }
}
