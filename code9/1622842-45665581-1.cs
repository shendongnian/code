    public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult Index(FormCollection collection)
            {
                string btn = Request.Params["submitID"];
    
                switch (btn)
                {
                    case "Upload1":
    
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var file = Request.Files[i];
                        }                      
                        break;
    
                    case "Upload2":
    
                        for (int i = 0; i < Request.Files.Count; i++)
                        {
                            var file = Request.Files[i];
                        }
                        break;
                }
    
                return View();
            }
