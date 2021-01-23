    JObject result = null;
    if (responseData != null)
    {
        object obj = responseData["Result"];
        if (obj != null)
        {
            string str = obj.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                result = JObject.Parse(str);
            }
        }
    }
