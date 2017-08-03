#r "Microsoft.WindowsAzure.Storage"
#load "model\customer.csx"
using System.Net;
using Microsoft.WindowsAzure.Storage.Table;

public static async Task<HttpResponseMessage> Crud<Microsoft.WindowsAzure.Storage.Table.ITableEntity>(
    HttpRequestMessage req, 
    IQueryable<Microsoft.WindowsAzure.Storage.Table.ITableEntity> inputTable, 
    CloudTable outputTable, 
    TraceWriter log,
    string partitionKey,
    Func<dynamic,Microsoft.WindowsAzure.Storage.Table.ITableEntity> project)
{
    //GetByKey
    string key = req.GetQueryNameValuePairs().FirstOrDefault(q => string.Compare(q.Key, "rowKey", true) == 0).Value;
    if(req.Method == HttpMethod.Get && !string.IsNullOrEmpty(key)) {
        var list = inputTable.Where(i=>i.RowKey == key).ToList();
        if(list.Count()>0) return req.CreateResponse(HttpStatusCode.OK, list.First(),"application/json");
        return req.CreateResponse(HttpStatusCode.NotFound, "Entity Not Found");
    }
    //GetAll
    if(req.Method == HttpMethod.Get && string.IsNullOrEmpty(key)) return req.CreateResponse(HttpStatusCode.OK, inputTable.ToList(),"application/json"); 
    //Delete
    if(req.Method == HttpMethod.Delete && !string.IsNullOrEmpty(key)){
        var item = new TableEntity
        {
            PartitionKey = partitionKey,
            RowKey = key,
            ETag = "*"
        };
        var operation = TableOperation.Delete(item);
        await outputTable.ExecuteAsync(operation);
        return req.CreateResponse(HttpStatusCode.NoContent);
    }
    var data = await req.Content.ReadAsAsync<object>();
    var entity = project(data); 
    //PostNew
    if(entity.RowKey == "0")
    {
        var newKey = Guid.NewGuid().ToString();
        entity.RowKey = newKey;
        var operation = TableOperation.Insert(entity);
        await outputTable.ExecuteAsync(operation);
        return req.CreateResponse(HttpStatusCode.OK, entity,"application/json");
    }
    //PostUpdate
    else{
        var operation = TableOperation.Replace(entity);
        await outputTable.ExecuteAsync(operation);
        return req.CreateResponse(HttpStatusCode.OK, entity,"application/json"); 
    }
 
}



