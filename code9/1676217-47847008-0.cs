    Data data = JsonConvert.DeserializeObject<Data>(body as string);    
    Type myType = Type.GetType(data.type);
    var item = Convert.ChangeType(data.data, myType);
    Console.WriteLine(item);
	Console.WriteLine(item.GetType());
