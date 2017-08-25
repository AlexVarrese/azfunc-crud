#load "../shared/model/customer.csx"
using System.Net;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

public static IList<Customer> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("test");
    var cnnString  = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
    using(var db = new SqlConnection(cnnString))
    {
        var list = db.Query<Customer>("select * from [dbo].[Customers]").ToList();
        return list;
    }
}
