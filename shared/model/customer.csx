#r "Microsoft.WindowsAzure.Storage"
using Microsoft.WindowsAzure.Storage.Table;

public class Customer : TableEntity
{
    public long Id { get; set; }
    public long LongId { get; set; }
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

    public static Func<dynamic, Customer> Project
    {
        get
        {
            return data =>
            {
                return new Customer
                {
                    PartitionKey = "Customer",
                    RowKey = data?.RowKey,
                    CompanyName = data?.CompanyName,
                    Address = data?.Address,
                    City = data?.City,
                    ContactName = data?.ContactName,
                    ContactTitle = data?.ContactTitle,
                    Country = data?.Country,
                    Fax = data?.Fax,
                    Phone = data?.Phone,
                    PostalCode = data?.PostalCode,
                    Region = data?.Region,
                    ETag = "*"
                };
            };
        }
    }
}

