#r "Microsoft.WindowsAzure.Storage"
using Microsoft.WindowsAzure.Storage.Table;

public class Employee : TableEntity
{
    public string EmployeeID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public string TitleOfCourtesy { get; set; }
    public string BirthDate { get; set; }
    public string HireDate { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string HomePhone { get; set; }
    public string Extension { get; set; }
    public string Photo { get; set; }
    public string Notes { get; set; }
    public string ReportsTo { get; set; }
    public string PhotoPath { get; set; }

    public static Func<dynamic,Employee> Project
    {
        get{
            return data => {
                // dynamic data = await req.Content.ReadAsAsync<object>();
                return new Employee{
                    PartitionKey = "Employee",
                    RowKey = data?.RowKey,
                    EmployeeID = data?.EmployeeID,
                    LastName = data?.LastName,
                    FirstName = data?.FirstName,
                    Title = data?.Title,
                    TitleOfCourtesy = data?.TitleOfCourtesy,
                    BirthDate = data?.BirthDate,
                    HireDate = data?.HireDate,
                    Address = data?.Address,
                    City = data?.City,
                    Region = data?.Region,
                    PostalCode = data?.PostalCode,
                    Country = data?.Country,
                    HomePhone = data?.HomePhone,
                    Extension = data?.Extension,
                    Photo = data?.Photo,
                    Notes = data?.Notes,
                    ReportsTo = data?.ReportsTo,
                    PhotoPath = data?.PhotoPath,
                    ETag = "*"
                };
            };
        }        
    }
}

