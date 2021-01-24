    [Route("ProvideData")]
	[HttpGet]
	public ActionResult ProvideData(string data, string connectionName)
	{
        if (!string.IsNullOrEmpty(data) && !string.IsNullOrEmpty(connectionName))
        {
            HttpContext.Items.Add("ConnectionName", connectionName);
            HttpContext.Items.Add("Data", data);
        }
			return Ok();
	}
