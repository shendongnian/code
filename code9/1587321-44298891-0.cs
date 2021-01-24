    [HttpPost]
    public IHttpActionResult CrearProducto(EProducto Producto)
    {
    	try
    	{
    		IHttpActionResult response;
    		HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.RedirectMethod);
    		if (ConnectionStringStore == string.Empty)
    		{
    			var request = HttpContext.Current.Items["MS_HttpRequestMessage"] as HttpRequestMessage;
    			var httpContext = (HttpContextWrapper)request.Properties["MS_HttpContext"];
    			ConnectionStringStore = httpContext.Session[EnumSession.Variable.KeyConfig.ToString()].ToString();
    		}
    		if (objBLProducto.ObtenerProductoRepetido(Producto, ConnectionStringStore).Count > 0) {
    			responseMsg.Content = new StringContent("Elemento duplicado");
    			response = ResponseMessage(responseMsg);
    			return response;
    		}
    		if (objBLProducto.InsertarProducto(Producto, ConnectionStringStore))
    		{
    			return Ok(Producto);
    		}
    		else
    		{
    			return InternalServerError();
    		}
    	}
    	catch (Exception Ex)
    	{
    		HelperLog.PutStackTrace(Ex);
    		return InternalServerError();
    	}
    }
