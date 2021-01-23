    using (var reader = SqlHelper.ExecuteXmlReader(Conn, CommandType.StoredProcedure, spName, ListParam.ToArray()))
	{
		if (reader == null) return;
		StringBuilder sb = new StringBuilder();
		While(reader.Read())
		{
			sb.AppendLine(reader.ReadOuterXml());
			string xmlVal = sb.ToString(); // You can get the xml as string here.
		}  
	}
