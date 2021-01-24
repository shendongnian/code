     public ActionResult Index(demo obj)
            {
              string path = Server.MapPath("~/app/");
            var read = System.IO.File.ReadAllText(path + "output.json");
            List<demo> lst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<demo>>(read);
            if (lst == null)
            {
                List<demo> _data = new List<demo>();
                _data.Add(obj);
               String json = Newtonsoft.Json.JsonConvert.SerializeObject(_data.ToArray());
                System.IO.File.WriteAllText(path + "output.json", json);
            }
            else
            {
                lst.Add(obj);
                String json = Newtonsoft.Json.JsonConvert.SerializeObject(lst);
                System.IO.File.WriteAllText(path + "output.json", json);
            }
            return View();
            }  
