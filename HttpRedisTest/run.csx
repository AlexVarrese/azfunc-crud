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
    if(string.IsNullOrEmpty(id)) return redisCustomer.GetAll();

    var intId = 0;
    if(Int32.TryParse(id,out intId)){
        return redisCustomer.GetById(id);
    }

    // var newTodo = new Customer
    // {
    //     Id = redisCustomer.GetNextSequence(),
    //     CompanyName = "Learn Redis",
    //     Address = "Brisbane",
    // };

    // redisCustomer.Store(newTodo);
    // Customer savedTodo = redisCustomer.GetById(newTodo.Id);    
    // "Saved Todo: {0}".Print(savedTodo.Dump());
    // log.Info(savedTodo.Dump());

    // // return redisCustomer.GetAllItemsFromList();

    throw new Exception();
}
