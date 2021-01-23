	string str = "Cust =Customer CustCR =Customer Credit Prod=Product SalesRep=Sales Rep TaxCat=Tax Category TaxId=Tax ID VolBill=Volume Billing";
	var separated = str.Split('=');
	string code = separated[0].Trim();
	var codeAndDescription = new Dictionary<string, string>();
	for (int i = 1; i < separated.Length - 1; i++)
	{
		int lastSpace = separated[i].Trim().LastIndexOf(' ');
		var description = separated[i].Substring(0, lastSpace).Trim();
		codeAndDescription.Add(code, description);
		code = separated[i].Substring(lastSpace + 1).Trim();
	}
	codeAndDescription.Add(code, separated[separated.Length - 1]);
	foreach (var kvp in codeAndDescription)
		Console.WriteLine(kvp);
