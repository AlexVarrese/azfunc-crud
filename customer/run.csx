#r "Microsoft.WindowsAzure.Storage"
#load "../shared/crud.csx"
#load "../shared/model/customer.csx"
using System.Net;
using Microsoft.WindowsAzure.Storage.Table;

public static async Task<HttpResponseMessage> Run(
    HttpRequestMessage req, 
    IQueryable<Customer> inputTable, 
    CloudTable outputTable, 
    TraceWriter log)
{
    return await Crud(req, inputTable, outputTable, log, "Customer", Customer.Project);
}
