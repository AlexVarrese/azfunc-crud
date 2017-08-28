#load "../shared/model/customer.csx"

using System;
using System.Configuration;
using System.Threading.Tasks;
using ServiceStack.Redis;
using ServiceStack.Text;

public static void Run(Customer customer, TraceWriter log)
{
    var cnnString  = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
    using(var db = new SqlConnection(cnnString))
    {
        string query ="";
        if(customer.Id==0)
        {
            command = @"INSERT INTO [dbo].[Customer] (CompanyName) values (@CompanyName)";
        }else{
            command = @"UPDATE [dbo].[Customer] SET CompanyName = @CompanyName WHERE Id = @Id";
        }

        var result = db.Execute(command,customer);
    }
}
