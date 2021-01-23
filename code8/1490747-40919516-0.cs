	string str = "Cust =Customer CustCR =Customer Credit Prod=Product SalesRep=Sales Rep TaxCat=Tax Category TaxId=Tax ID VolBill=Volume Billing";
	var separated = str.Split('=');
	string code = separated[0].Trim();
	var codeAndDescription = new Dictionary<string,string>();
	foreach (var sep in separated.Skip(1).Take(separated.Length - 2))
	{
		int lastSpace = sep.Trim().LastIndexOf(' ');
		var description = sep.Substring(0, lastSpace).Trim();
		codeAndDescription.Add(code, description);
		code = sep.Substring(lastSpace + 1).Trim();
	}
	codeAndDescription.Add(code, separated.Last());
	foreach(var kvp in codeAndDescription)
		Console.WriteLine(kvp);
