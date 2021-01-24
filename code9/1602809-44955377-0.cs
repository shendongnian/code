	public static PayrollItem[] GetPayrollItems(XmlDocument xmlDoc)
	{
		var items = new List<PayrollItem>();
		var node = xmlDoc.FirstChild; //SOAP-ENV:Envelope
		if (node != null)
		{
			node = node.FirstChild; //SOAP-ENV:Body
			if (node != null)
			{
				node = node.FirstChild; //ns1:wsdlGetValuesResponse
				if (node != null)
				{
					node = node.FirstChild;  //return
					if (node != null)
					{
						int count = node.ChildNodes.Count;
						foreach (XmlNode nodeItem in node.ChildNodes)
						{
							PayrollItem item = new PayrollItem();
							item.EmpName = nodeItem["empName"].InnerText;
							item.BadgeNo = nodeItem["badgeNo"].InnerText;
							item.CostCentre = nodeItem["costCentre"].InnerText;
							item.Date = nodeItem["date"].InnerText;
							item.In = nodeItem["in"].InnerText;
							item.Out = nodeItem["out"].InnerText;
							items.Add(item);
						}
					}
				}
			}
		}
		return items.ToArray();
	}
