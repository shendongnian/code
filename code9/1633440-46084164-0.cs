    public T GetByID<T>(BaseAPI api) where T: class
    {
        ....
        try
        {
            var response = (HttpWebResponse)httpRequest.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
    
            T returnObject = JsonConvert.DeserializeObject<T>(responseString);
            return returnObject;
        }
        catch (Exception ex)
        {
            return default(T);
        }
    }
