    [HttpPost]
        public ActionResult userById()
        {
            string receivedData;
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://www.amisteriousurl.com");
            req.ContentType = "application/json";
            var response = (HttpWebResponse)req.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                receivedData = sr.ReadToEnd();
            }
            var data = JsonConvert.DeserializeObject<RootObject>(receivedData);
            List<User> userList = data.clients.ToList();
            ViewData["results"] = getId(userList);
            return View("Index");
        }
    
    private string getId(List<User> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
               
                sb.Append(item.Id);
                sb.Append("\n");
            }
            return sb.ToString();
        }
