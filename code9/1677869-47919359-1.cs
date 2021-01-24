    [HttpGet]//http get as it return file 
            public HttpResponseMessage GetTextFile()
            {
                //below code locate physcial file on server 
                var localFilePath = HttpContext.Current.Server.MapPath("~/timetable.txt");
                HttpResponseMessage response = null;
                if (!File.Exists(localFilePath))
                {
                    //if file not found than return response as resource not present 
                    response = Request.CreateResponse(HttpStatusCode.Gone);
                }
                else
                {
                    string data = string.Join(" ", File.ReadAllLines(localFilePath));
                    response = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(data, Encoding.UTF8, "text/html")
                    };
                }
                return response;
            }
