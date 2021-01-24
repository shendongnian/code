    void webREquest(string url)
            {
                // taken from https://msdn.microsoft.com/en-us/library/system.net.webexception.response(v=vs.110).aspx
                HttpWebRequest myHttpWebRequest = null;
                HttpWebResponse myHttpWebResponse = null;
                try
                {
                    // Create a web request for an invalid site. Substitute the "invalid site" strong in the Create call with a invalid name.
                    myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
    
                    // Get the associated response for the above request.
                    myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    myHttpWebResponse.Close();
                }
                catch (WebException e)
                {
                    Console.WriteLine("This program is expected to throw WebException on successful run." +
                              "\n\nException Message :" + e.Message);
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                        Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    //close on myHttpWebResponse
                    myHttpWebResponse?.Close();
    
                    //mark myHttpWebRequest for collection
                    myHttpWebRequest = null;
                }
            }
