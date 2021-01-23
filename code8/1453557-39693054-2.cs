    Test C = Test.B;
    Console.WriteLine(C == Test.B); //Returns true
    string Json = JsonConvert.SerializeObject(C, new JsonSerializerSettings { ContractResolver = ISerializableRealObjectContractResolver.Instance });
    Console.WriteLine(Json);
    C = JsonConvert.DeserializeObject<Test>(Json, new JsonSerializerSettings { ContractResolver = ISerializableRealObjectContractResolver.Instance });
    Console.WriteLine(C == Test.B); //Still returns true      
    if (!object.ReferenceEquals(C, Test.B))
    {
        throw new InvalidOperationException("!object.ReferenceEquals(C, Test.B)");
    }
	else
	{
		Console.WriteLine("Global singleton instance deserialized successfully."); 
	}
