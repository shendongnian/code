	Dictionary<int, string> dictFriends = new Dictionary<int, string>();
	
	dictFriends.Add(1, "Alice");
	dictFriends.Add(2, "Bob");
	
	string jsonString;
	using (MemoryStream ms = new MemoryStream()) {
		//NB: DataContractJsonSerializer is in assembly System.Runtime.Serialization.dll - and others; http://stackoverflow.com/a/2682197/361842 
		DataContractJsonSerializer dcjs = new DataContractJsonSerializer(dictFriends.GetType());
		dcjs.WriteObject(ms, dictFriends);
		
		ms.Position = 0;
		using(StreamReader sr = new StreamReader(ms)) {
			jsonString = sr.ReadToEnd();
		}
	}
	
	Debug.WriteLine(jsonString);
