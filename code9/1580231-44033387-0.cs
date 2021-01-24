	public HttpResponseMessage SaveCountry(OrderList cnt)
	{
		var country = db.Database.SqlQuery<string>("Sp_OrderList", cnt.OrderId, cnt.OrderName, cnt.OrderDate);
		return Request.CreateResponse(HttpStatusCode.OK, country);
	}
