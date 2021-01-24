    var query = "select * from Customer where ID in (@parmCustId)";
	using (AseCommand cmd = new AseCommand("", conn))
	{
		var replacement = "";
		for (int i = 0; i < arrList.Length; i++)
		{
			var id = arrList[i];
			var p = "@parmCustId" + i.ToString();
			cmd.Parameters.AddWithValue(p, id);
			replacement += p;
			if (i != arrList.Length - 1)
			{
				replacement += ",";
			}
		}
		cmd.CommandText = query.Replace("@parmCustId", replacement);
		using (AseDataReader dr = cmd.ExecuteReader())
		{
			if (dr.HasRows)
			{
	    		//do something
			}
		}
	}
