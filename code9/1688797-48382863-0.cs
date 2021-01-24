	string url = "https://www.google.co.uk/search?q=";
	//string url = "http://localhost:52595/specificAttractions.aspx?country=";
	string parm = "Bora Bora, French Polynesia";
	Console.WriteLine(url + parm);
	Console.WriteLine(url + HttpUtility.UrlEncode(parm), System.Text.Encoding.UTF8);
	Console.WriteLine(url + HttpUtility.UrlPathEncode(parm), System.Text.Encoding.UTF8);
	Console.WriteLine(HttpUtility.UrlEncode(url + parm), System.Text.Encoding.UTF8);
