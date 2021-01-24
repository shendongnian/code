        public string httpPostElevationRequest( string lon,string lat)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] response =
                    client.UploadValues(BASEURL, new NameValueCollection()
                    {
                    { "x", lon },
                    { "y", lat },
                    {"unit", "feet" },
                    {"output","json" },
                    });
                    string result = System.Text.Encoding.UTF8.GetString(response);
                    responseString = result;
                }
                return responseString;
            }
            catch(Exception eX)
            {
                return null;
            }
        }
