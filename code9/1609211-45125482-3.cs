     [HttpPost, HttpGet]
            public HttpResponseMessage stopxxxxx(string passedId)
            {
            string returnedValue = "Error Stopping xxxxx";
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(returnedValue, System.Text.Encoding.UTF8, "text/plain")
            };
        }
