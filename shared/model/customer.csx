public class Customer : TableEntity
{
    public string CompanyName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Country { get; set; }
    public string Fax { get; set; }
    public string Phone { get; set; }
    public string PostalCode { get; set; }
    public string Region { get; set; }
}

public static async Task<Customer> ProjectCustomer(HttpRequestMessage req)
{
    dynamic data = await req.Content.ReadAsAsync<object>();
    return new Customer{
        PartitionKey = "Customer",
        RowKey = data?.RowKey,
        CompanyName = data?.CompanyName,
        City = data?.City,
        ETag = "*"
    };
}