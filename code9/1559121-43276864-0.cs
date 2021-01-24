    public HttpResponseMessage UpdateHotelAvailability()
        {
            string incomingText = this.Request.Content.ReadAsStringAsync().Result;
            XDocument doc = XDocument.Parse(incomingText);
            XNamespace ns = doc.Root.Name.Namespace;
            var v = from h in doc.Descendants(ns+"StatusApplicationControl")
                    select new StatusApplicationControl
                    {
                        Start = h.Attribute("Start").Value,
                        End = h.Attribute("End").Value
                    };
            
            HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.OK, 200);
            return res;
        }
