    [HttpPost]
            [CatchException]
            public bool ImportBundlesFromCsv()
            {
                var a = Request.Content.ReadAsByteArrayAsync();
    
                //convert to Stream if needed
                Stream stream = new MemoryStream(a.Result); // a.Result is byte[]
                // convert to String if needed
                string result = System.Text.Encoding.UTF8.GetString(a.Result);
    
                // your code
    
                return true;
            }
