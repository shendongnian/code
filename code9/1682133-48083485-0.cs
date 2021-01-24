    string text = null;
    using (WebResponse response = WebRequest.Create(url).GetResponse())
    {
       using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("iso-8859-1")))
       {
          text = reader.ReadToEnd();
          reader.Close();
       }
       response.Close();
     }
