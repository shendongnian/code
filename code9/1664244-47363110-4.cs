         private string MAKER_URL = "http://localhost:2390/api/vehicle";
         public ActionResult Index()
         {
                ViewBag.listMakers = new SelectList(GetMakers(), "MakeId","MakeName");
                return View();
         }
    
         public IEnumerable<Make> GetMakers()
         {
           try
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(MAKER_URL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync("vehicle/MakersList").Result;
                    if (response.IsSuccessStatusCode)
                        return response.Content.ReadAsAsync<IEnumerable<Make>>().Result;
                    return null;
                }
                catch
                {
                    return null;
                }
    
         }
