     public ActionResult Index(demo obj)
            {
                //desalinize
                List<demo> lst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<demo>>(result);
                lst.Add(obj);
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(lst);
                string path = Server.MapPath("~/app/");
                //// Write that JSON to txt file,  
                //var read = System.IO.File.ReadAllText(path + "output.json");
                System.IO.File.WriteAllText(path + "output.json",  json);
                return View();
            }  
