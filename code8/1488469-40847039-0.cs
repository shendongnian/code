	[WebMethod]
	public string ShowDate()
	{
		DataTable dt = new DataTable();
		dt = conn.CheckTable("date");
		List<DateTime> list = new List<DateTime>();
		for (int i = 0; i < dt.Rows.Count; i++)
		{
			list.Add(Convert.ToDateTime(dt.Rows[i]["Date"]).ToString());
		}
		JavaScriptSerializer js = new JavaScriptSerializer();
		string lines = js.Serialize(list);
		return lines;
	}
