#r "Microsoft.WindowsAzure.Storage"
#load "../shared/crud.csx"
#load "../shared/model/employee.csx"
using System.Net;
using Microsoft.WindowsAzure.Storage.Table;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, IQueryable<Employee> inputTable, CloudTable outputTable, TraceWriter log)
{
    return await Crud<Employee>(req, inputTable, outputTable, log, "Employee", Employee.Project);
}
