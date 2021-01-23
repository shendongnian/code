        string text = "4200 47 Street Alberta Beach, T0E 0A0 AB 780-544-0137";
		string pattern = @"\d{3}-\d{3}-\d{4}$"; 
		Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
		Match match = rgx.Match (text);
		if (match.Success) {
			string phoneNumber = match.Value;
		    Console.WriteLine (phoneNumber); //780-544-0137
         	string rest = text.Substring(0,text.Length-phoneNumber.Length);
			Console.WriteLine (rest);
		}
