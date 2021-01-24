    try
    {
        using (var response = (HttpWebResponse)requisicao.GetResponse()) // **here happens the exception**
        {
            using (var stream = new StreamReader(response.GetResponseStream()))
                retorno = JsonConvert.DeserializeObject<TModelo>(stream.ReadToEnd());
        }
    }
    catch (WebException e)
    {
        WebResponse response = e.Response;
        using (StreamReader reader =
            new StreamReader(response.GetResponseStream()))
        {
            string text = reader.ReadToEnd();//Content of error message
        }
    }
