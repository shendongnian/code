	private void CreateTransaction(string webServiceUrl, string ticket, double costPerUnit) {
		string soapAction = "Company.WebService/ICompanyWebService/CreatePurchaseTransaction";
		var soapEnvelope = new XElement(soapNs + "Envelope",
							new XAttribute(XNamespace.Xmlns + "soapenv", "http://schemas.xmlsoap.org/soap/envelope/"),
							new XAttribute(XNamespace.Xmlns + "top", "Company.WebService"),						
						new XElement(soapNs + "Body", 
							new XElement(topNs + "CreatePurchaseTransaction", 
								new XElement(topNs + "command", 
									new XElement(topNs + "BillTransaction", "true"),
									new XElement(topNs + "BillingComments", "Created By C# Code"),
									new XElement(topNs + "Department", "Development"),
									new XElement(topNs + "LineItems", GetManualPurchaseLineItems(topNs, costPerUnit)),									
									new XElement(topNs + "Surcharge", "42.21"),
									new XElement(topNs + "Tax", "true"),
									new XElement(topNs + "TransactionDate", DateTime.Now.ToString("yyyy-MM-dd"))
						))));
		var webResp = ExecutePost(webServiceUrl, soapAction, soapEnvelope.ToString());	
		if (webResp.StatusCode != HttpStatusCode.OK) 
			throw new Exception("Unable To Create The Transaction");
		var sr = new StreamReader(webResp.GetResponseStream());
		var xDoc = XDocument.Parse(sr.ReadToEnd());
		var result = xDoc.Descendants(topNs + "ResultType").Single();
		if (result.Value.Equals("Success", StringComparison.CurrentCultureIgnoreCase) == false)
			throw new Exception("Unable to post the purchase transaction.  Look in the xDoc for more details.");
	}
	
	private IEnumerable<XElement> GetManualPurchaseLineItems(XNamespace topNs, double costPerUnit) {
		var lineItems = new List<XElement>();
		lineItems.Add(new XElement(topNs + "PurchaseLineItem",
							new XElement(topNs + "Count", "5"),
							new XElement(topNs + "ExpenseClass", "Tech Time"),
							new XElement(topNs + "ItemName", "Brushing and Flossing"),
							new XElement(topNs + "Location", "Your House"),
							new XElement(topNs + "UnitCost", costPerUnit.ToString("#.00"))));
		return lineItems;
	}
