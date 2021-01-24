       if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                StreamReader stream = new StreamReader(response.GetResponseStream());
                string final_response = stream.ReadToEnd();
                return final_response;
                }
     else
                {
                    Logger.CreateLogEntry("<== WebRequest ", "Could not Connect to server. Server Response Code: " + response.StatusCode);
                    //Add bad request handler
                    return null;
                }
