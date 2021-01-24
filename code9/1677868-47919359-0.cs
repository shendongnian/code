     var localFilePath = HttpContext.Current.Server.MapPath("~/timetable.txt");
                HttpResponseMessage response = null;
                if (!File.Exists(localFilePath))
                {
                    //if file not found than return response as resource not present 
                    response = Request.CreateResponse(HttpStatusCode.Gone);
                }
                else
                {
                    response = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(string.Join(" ", File.ReadAllLines(localFilePath)), Encoding.UTF8, "application/json")
                    };
      }
