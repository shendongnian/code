    using System.Net.Http;
    using System.Threading.Tasks;
    
    using Amazon.Lambda.Core;
    using Amazon.Lambda.Serialization.Json;
    
    namespace LambdaHttpRequest
    {
        public class Handler
        {
            [LambdaSerializer(typeof(JsonSerializer))]
            public static async Task<string> MakeRequest()
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://www.amazon.com/");
                return response.ToString();
            }
        }
    }
