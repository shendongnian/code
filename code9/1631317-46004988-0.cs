    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Web;
    using System.Text;
    using System.Threading.Tasks;
    namespace SO
    {
        [ServiceContract]
        public class TestServer
        {
            static WebServiceHost _host = null;
            public static Task Start()
            {
                var tcs = new TaskCompletionSource<object>();
                try
                {
                    _host = new WebServiceHost(typeof(TestServer), new Uri("http://0.0.0.0:8088/TestServer"));
                    _host.Opened += (s, e) => { tcs.TrySetResult(null); };
                    _host.Open();
                }
                catch(Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            
                return tcs.Task;
            }
            //A method that accepts anything :)
            [OperationContract, WebInvoke(Method = "*", UriTemplate ="*")]
            public Message TestMethod(Stream stream )
            {
                var ctx = WebOperationContext.Current;
                var request  = ctx.IncomingRequest.UriTemplateMatch.RequestUri.ToString();
                var body = new StreamReader(stream).ReadToEnd();
                Console.WriteLine($"{ctx.IncomingRequest.Method} {request} {Environment.NewLine}BODY:{Environment.NewLine}{body}");
            
                return ctx.CreateTextResponse( JsonConvert.SerializeObject( new { status = "OK", data= "anything" }), "application/json", Encoding.UTF8);
            }
        }
        public class TestClient
        {
            public static async Task Test()
            {
                await TestServer.Start();
                var client = new HttpClient();
                var objToSend = new { name = "L", surname = "B" };
                var content = new StringContent( JsonConvert.SerializeObject(objToSend) );
                var response = await client.PostAsync("http://localhost:8088/TestServer/TestMethod?aaa=1&bbb=2", content);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }
