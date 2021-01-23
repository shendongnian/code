    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web.Http;
    
    namespace MyTestTwo.Controllers
    {
        public class Test2Controller : ApiController
        {
            public IHttpActionResult Get()
            {
                var employeesTask = GetEmp();
                employeesTask.Wait();
    
                var employees = employeesTask.Result;
    
                return Ok(employees);
            }
    
            private async Task<IEnumerable<string>> GetEmp()
            {
                IEnumerable<string> response = new List<string>();
                var cl = new HttpClient();
                cl.BaseAddress = new Uri("http://localhost/MyTestApp/");
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var sucSender = await cl.PostAsJsonAsync("api/MyTest", "test").ConfigureAwait(false);
                if (sucSender.IsSuccessStatusCode)
                {
                    response = await sucSender.Content.ReadAsAsync<IEnumerable<string>>();
                }
    
                return response;
            }
        }
    }
