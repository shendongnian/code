    StringBuilder sb = new StringBuilder();
    using (var reader = SqlHelper.ExecuteXmlReader(Conn, CommandType.StoredProcedure, spName, ListParam.ToArray()))
	{
		if (reader == null) return;		
		while(reader.Read())
		{
			sb.AppendLine(reader.ReadOuterXml());
		}
        string xmlVal = sb.ToString(); // You can get the xml as string here. 
	}
