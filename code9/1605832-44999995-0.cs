    try
    {
        using (HttpWebResponse resp = httpparse.response(r))
        {
            if(resp != null)
            {
                using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                {
                    string s = "";
                    try { s = sr.ReadToEnd(); }
                    catch (IOException) { return "2"; }
                }
            } else
            {
                return "2";
            }
        }
    }
    catch (WebException)
    {
        return "2";
    }
