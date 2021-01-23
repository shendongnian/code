    if (request.Headers.Contains("Origin") && request.Method.Method == "OPTIONS")
                {
                    var response = new HttpResponseMessage();
                    response.StatusCode = HttpStatusCode.OK;
                    response.Headers.Add("Access-Control-Allow-Origin", "*");
                    response.Headers.Add("Access-Control-Allow-Headers", "Origin, Content-Type, Accept, Authorization");
                    //Worked before for deletes but CORS came back out of blue for deletes so changed * for DELETE and content doing al CRUD at the moment..
                    response.Headers.Add("Access-Control-Allow-Methods", "DELETE, POST, PUT, OPTIONS, GET");
                }
