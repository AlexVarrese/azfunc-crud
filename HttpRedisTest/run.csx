#load "../shared/model/customer.csx"

using System;
using System.Net;
using ServiceStack.Redis;
using ServiceStack.Text;
using System.Configuration;

public static Customer Run(HttpRequestMessage req, TraceWriter log)
{
    var cnnString  = ConfigurationManager.ConnectionStrings["MyRedis"].ConnectionString;

    var redisManager = new RedisManagerPool(cnnString);
    var redis = redisManager.GetClient();

    var redisTodos = redis.As<Customer>();
    var newTodo = new Customer
    {
        Id = redisTodos.GetNextSequence(),
        CompanyName = "Learn Redis",
        Address = "Brisbane",
    };

    redisTodos.Store(newTodo);
    Customer savedTodo = redisTodos.GetById(newTodo.Id);    
    "Saved Todo: {0}".Print(savedTodo.Dump());
    log.Info(savedTodo.Dump());

    // return redisTodos.GetAllItemsFromList();

    return savedTodo;
}
