     public ActionResult Sample()
        {
           string getval = Request.QueryString["id"];
           string concat = @"{""data"":" + getval + "}";
           
            ValList vl = new JavaScriptSerializer().Deserialize<ValList>(concat);
            foreach (var item in vl.data)
            {
                Console.WriteLine("dept: {0}, name: {1}", item.dept, item.name);
            }
            return View();
        }
        public class ValList
        {
         
            public List<Values> data { get; set; }
        }
        public class Values
        {
            public string name { get; set; }
            public string dept { get; set; }
        }
