           ctx.Configuration.AutoDetectChangesEnabled = false;
           var d1 = Request.Content.ReadAsStreamAsync().Result;
           using (StreamReader sr = new StreamReader(d1))
                    {
                        string rawJson = sr.ReadToEnd();
                        //....Then you could return the response
                    }
