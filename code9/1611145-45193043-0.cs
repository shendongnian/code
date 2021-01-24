     public class Requests
     {
     //...
     public async Task<ResultType> Create<ResultType>(string uri)
     {
     //TODO implementation of httpclient POST logic go here
                
    var data = await results.Content.ReadAsStringAsync();
    var result = JsonConvert.DeserializeObject<ResultType>(data);
    return result;
    }
