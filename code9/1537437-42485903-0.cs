    try
            {           
               
                using (var client = new WebClient())
                {
                    client.DownloadFile({url},{filename to save});
                   
                }               
            }
            catch (WebException ex)
            {
                if(ex.Status==WebExceptionStatus.Timeout) //Timeout 
                {
                   
                }
                if (ex.Status == WebExceptionStatus.ConnectFailure) //Connection error 
                {
                    
                }
                if (ex.Status == WebExceptionStatus.NameResolutionFailure) //URL not valid
                {
                   
                }
                if (ex.Response!= null)
                {
                    if (((HttpWebResponse)ex.Response).StatusCode == HttpStatusCode.NotFound)
                    {
                        // error 404, do what you need to do
                       
                    }                   
                }               
            }
