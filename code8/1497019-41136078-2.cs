	string jsn = File.ReadAllText("YourJSON.txt");
	List<RootObject> ro = JsonConvert.DeserializeObject<List<RootObject>>(jsn);
	foreach(UserClaim uc in ro[0].user_claims)
	{
		if(uc.val=="FIRSTNAME")
		{
			//Do whatever you want.
		}
        //or
		if(uc.typ.Contains("givenname"))
		{
			Console.WriteLine(uc.val);
		}
	}
