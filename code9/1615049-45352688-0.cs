    public static async Task<string> GetResponseStr(string link)
            {
                var final_response = string.Empty;
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
                    StreamReader stream = new StreamReader(response.GetResponseStream());
                    final_response = stream.ReadToEnd();
                }
                catch (Exception ex)
                {
                    //DO whatever necessary like log or sending email to notify you   
                }
                
                return final_response;
            }
