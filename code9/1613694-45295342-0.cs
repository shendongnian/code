     NameValueCollection coll = HttpUtility.ParseQueryString(body);
     var response = new StringBuilder();
     foreach (var key in col1.AllKeys)
     {
         response.Append(String.Format(@"form[""{0}""] = {1}\r\n", key, col1[key]));  //Edit the format string to taste
     }
     Debug.Write(response.ToString());
