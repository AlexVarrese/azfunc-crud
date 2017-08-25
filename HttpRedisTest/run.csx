using System.Net;
using StackExchange.Redis;

public class Todo
{
    public long Id { get; set; }
    public string Content { get; set; }
    public int Order { get; set; }
    public bool Done { get; set; }
}

public static Todo Run(HttpRequestMessage req, TraceWriter log)
{
    var cnnString  = ConfigurationManager.ConnectionStrings["MyRedis"].ConnectionString;
    // var redis = ConnectionMultiplexer.Connect(connString);

    var redisManager = new RedisManagerPool(cnnString);
    var redis = redisManager.GetClient();

    var redisTodos = redis.As<Todo>();
    var newTodo = new Todo
    {
        Id = redisTodos.GetNextSequence(),
        Content = "Learn Redis",
        Order = 1,
    };

    redisTodos.Store(newTodo);
    Todo savedTodo = redisTodos.GetById(newTodo.Id);    
    "Saved Todo: {0}".Print(savedTodo.Dump());
    return savedTodo;
}
