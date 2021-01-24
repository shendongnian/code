    public class RecipeController : Controller
        {
    
            public async Task<ActionResult> Index()
            {
                List<Ingredient> RecInfo = new List<Ingredient>();
    
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri("https://api.edamam.com");
    
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api.edamam.com/search?q=chicken&app_id=a88093f8&app_key=4513de36c431f9936462ef4391f631e4&from=0&to=3&calories=gte%20591,%20lte%20722&health=alcohol-free");
    
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var name = Res.Content.ReadAsStringAsync().Result;
    
                        //Deserializing the response recieved from web api and storing into the Employee list  
                        RecInfo = JsonConvert.DeserializeObject<List<Ingredient>>(name);
    
                    }
                    //returning the employee list to view  
                    return View(RecInfo);
                }
            }
    }
