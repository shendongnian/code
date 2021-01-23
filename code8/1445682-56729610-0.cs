    [HttpPost]
    public async Task<ActionResult> Index()
        {
            try
            {
                var req = Request.InputStream; //get Request from telegram 
                var responsString = new StreamReader(req).ReadToEnd(); //read request
                RootObject ro = JsonConvert.DeserializeObject<RootObject>(responsString);
            }
            catch (Exception ex)
            {
                return Content("Error");
            }
            // This code hint to telegram Ttat , I Get Message And dont need to send this message again
            return Content("{\"ok\":true}");
        }
