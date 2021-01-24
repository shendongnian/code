    try
            {
                var request = (HttpWebRequest)WebRequest.Create(URL);
                request.ContentType = "application/json";
                request.Method = "POST";
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        var1 = "example1",
                        var2 = "example2"
                    });
                    streamWriter.Write(json);
                }
                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    return Request.CreateResponse(HttpStatusCode.OK, new { Respuesta = result }, "application/json");
                }
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Respuesta = e.ToString() }, "application/json");
            }
        }
