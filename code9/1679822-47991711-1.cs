     public ActionResult Index(demo obj)
            {
        var array = new [] {obj};
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(array);
                string path = Server.MapPath("~/app/");
                //// Write that JSON to txt file,  
                //var read = System.IO.File.ReadAllText(path + "output.json");
                System.IO.File.WriteAllText(path + "output.json",  json);
                return View();
            }  
