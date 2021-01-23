    public HttpResponseMessage Get(int id)
    {
         return Request.CreateResponse<Resp>(HttpStatusCode.Accepted, 
                    new Resp { 
                        ID = 1, 
                        Site = "   34.4   ", 
                        PressureReading = "0     ", 
                        PressureTrend = 42 });
    }
