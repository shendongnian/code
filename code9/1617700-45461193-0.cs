    public class wclients
    {
        public bool status { get; set; }
        public string message { get; set; }
        public IEnumerable<Account> data { get; set; }
    }
    public class Account
    {
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
    public ActionResult API()
    {
        var client = new WebClient();
        var text = client.DownloadString("https://www.example.com/api/all-users?name=user%20&pass=password");
        wclients clients = JsonConvert.DeserializeObject<wclients>(text);
        if (wclients.message == "success")
        {
            ViewBag.name = clients.data;
        }
        return View();
    }
