#load "../shared/model/customer.csx"
using System.Net;

public static async Task<Customer> Run(HttpRequestMessage req, TraceWriter log, IAsyncCollector<Customer> topicQueue)
{
    Customer data = await req.Content.ReadAsAsync<Customer>();
    topicQueue.AddAsync(data);
    return data;
}
