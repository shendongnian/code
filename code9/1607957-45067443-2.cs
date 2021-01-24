    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using RestSharp;
    
    namespace DemoWebCore.Controllers
    {
        public class HomeController : Controller
        {
            public async Task<IActionResult> ImageFromPath()
            {
                RestClient client = new RestClient("https://i.stack.imgur.com/hM8Ah.jpg?s=48&g=1");
                RestRequest request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("authorization", "Basic aYu7GI");
                TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
                RestRequestAsyncHandle handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
                RestResponse response = (RestResponse)await taskCompletion.Task;
                return Ok("data:image/png;base64," + Convert.ToBase64String(response.RawBytes));
            }
        }
    }
