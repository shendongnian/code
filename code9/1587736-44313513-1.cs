    public ActionResult Create([Bind(Include = "Email,FirstName,LastName")] ApprovedUsers approvedUsers)
    { 
        try
        {
            using (WebClient client = new WebClient())
            {
                token = Session.GetDataFromSession<string>("access_token");
                client.Headers.Add("authorization", "Bearer " + token);
                byte[] response = client.UploadValues(apiUrl, "POST", new NameValueCollection()
                {
                    { "Email", approvedUsers.Email },
                    { "FirstName",approvedUsers.FirstName },
                    { "LastName",approvedUsers.LastName }
                });
    
                string result = System.Text.Encoding.UTF8.GetString(response);            
            }
        }
        catch
        {
           TempData["Error"] = "Email Exists";});
        }
    
      RedirectToAction("Index");
 
     }
    public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page, string error)
      {
          ViewBag.Message = TempData["Error"].ToString();
      }
