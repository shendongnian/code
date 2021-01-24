    public class HomeController : Controller  
    {  
        //Hosted web API REST Service base url  
        string Baseurl = "http://xxx.xxx.xx.x:xxxx/";      
        public async Task<ActionResult> Index()  
        {  
            List<Employee> EmpInfo = new List<Employee>();  
                  
            using (var client = new HttpClient())  
            {  
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);  
      
                client.DefaultRequestHeaders.Clear();  
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));  
                      
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Employee/GetAllEmployees");  
      
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)  
                {  
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;  
      
                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);  
      
                }  
                //returning the employee list to view  
                return View(EmpInfo);  
            }  
         }  
    }  
