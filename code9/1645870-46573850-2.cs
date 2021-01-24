    public static DataTable GetIDSData(string sXMLString)
    {
	  DataTable result = new DataTable();
	
	result.Columns.Add("Success");
	result.Columns.Add("ErrorMessage");
	result.Columns.Add("ID");
	result.Columns.Add("PE_NAME");
	result.Columns.Add("PE_ID");
	result.Columns.Add("CODE");
	result.Columns.Add("DATA");
	XmlDocument xmlDoc = new XmlDocument();
	xmlDoc.InnerXml = sXMLString;
	XmlElement root = xmlDoc.DocumentElement;
	XDocument doc = XDocument.Parse(sXMLString);
	XmlNode node = xmlDoc.SelectSingleNode("DATA_RESPONSE/DATA");
	if (node != null)
	{
		var AddressInfoList = doc.Root.Descendants("ROW").Select(Address => new
		{
			ID = Address.Attributes("ID").Select(i=>i.Value) ,
			PEName = Address.Attributes("PE_NAME").Select(i=>i.Value),
			PEID = Address.Attributes("PE_ID").Select(i=>i.Value),
			Code = Address.Attributes("CODE").Select(i=>i.Value),
			Data = Address.Attributes("DATA").Select(i=>i.Value),
		}).ToList();
		AddressInfoList.ForEach(e => 
		{
			e.Code.ToList().ForEach(c =>
			{
				DataRow row = result.NewRow();
				if (!string.IsNullOrEmpty(c))
				{
					
					row["Success"] = true;
					row["ErrorMessage"] = "";
					row["ID"] = e.ID.First();
					row["PE_NAME"] = e.PEName.First();
					row["PE_ID"] = e.PEID.First();
					row["CODE"] = e.Code.First();
					row["DATA"] = e.Data.First();
				}
				else
				{
					row["Success"] = false;
					row["ErrorMessage"] = "Invalid Code; code is empty.";
				}
				result.Rows.Add(row);
		
		});});
		result.Dump();
		return result;
	}
	return result;
