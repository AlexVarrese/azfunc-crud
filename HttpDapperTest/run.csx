#load "../shared/model/customer.csx"
using System.Net;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    var cnnString  = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
    using(IDbConnection connection = new SqlConnection(cnnString))
    {
        return db.Query<Cutomer>("select * from [dbo].[Customers]").ToList();
    }
    return req.CreateResponse(HttpStatusCode.OK, ":D");
}
