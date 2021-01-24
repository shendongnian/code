    String FinalURL = "";
    foreach (string URLt in URLtests)
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(URLt);
                myHttpWebRequest.AllowAutoRedirect = false;
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                int resulting = (int)myHttpWebResponse.StatusCode;
                if (resulting == 200)
                {
                    String Urlnew = URLt;
                    FinalURL = URLt.Replace("https://", "").Replace("http://", "");
                    break;
                }
            }
