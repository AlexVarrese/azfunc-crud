#load "../shared/model/customer.csx"

using System.Net;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

public static void Run(Customer customer, TraceWriter log)
{
    var cnnString  = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
    using(var db = new SqlConnection(cnnString))
    {
        string command = "";
        if(customer.Id==0)
        {
            command = @"INSERT INTO [dbo].[Customers] (CompanyName) values (@CompanyName)";
        }else{
            command = @"UPDATE [dbo].[Customers] SET CompanyName = @CompanyName WHERE Id = @Id";
        }

        var result = db.Execute(command,customer);
    }
}
