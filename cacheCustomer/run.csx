#load "../shared/model/customer.csx"

using System;
using System.Threading.Tasks;

public static void Run(Customer customer, TraceWriter log)
{
    var redisString  = ConfigurationManager.ConnectionStrings["MyRedis"].ConnectionString;
    var redisManager = new RedisManagerPool(redisString);
    var redis = redisManager.GetClient();
    var redisCustomer = redis.As<Customer>();
    redisCustomer.Store(item);
}
