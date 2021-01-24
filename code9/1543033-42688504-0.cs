     public ActionResult test (string array)
            {
                string[] result = System.Web.Helpers.Json.Decode<string[]>(array);
              
                return View();
              
            }
