    try
    {
    	using (var response = (HttpWebResponse)requisicao.GetResponse()) // **here happens the exception**
    	{
    		using (var stream = new StreamReader(response.GetResponseStream()))
    			retorno = JsonConvert.DeserializeObject<TModelo>(stream.ReadToEnd());
    	}
    }
    catch(Exception ex)
    {
    	var model = new TModelo(){
    		ErrorMessage = "Error occured",
    		ErrorDetail = ex.Message + ex.StackTrace
    	}
    }
