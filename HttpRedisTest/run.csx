#load "../shared/model/customer.csx"

using System;
using System.Net;
using ServiceStack.Redis;
using ServiceStack.Text;
using System.Configuration;

public static dynamic Run(HttpRequestMessage req, string id, TraceWriter log)
{
    var cnnString  = ConfigurationManager.ConnectionStrings["MyRedis"].ConnectionString;

    var redisManager = new RedisManagerPool(cnnString);
    var redis = redisManager.GetClient();

    var redisCustomer = redis.As<Customer>();

    var intId = 0;
    if(Int32.TryParse(id,out intId)){
        return redisCustomer.GetById(id);
    }
    return redisCustomer.GetAll();
}
