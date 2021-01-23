	List<Data> dataList = new List<Data>
	{
		new Data { code = 1, name = "A" },
		new Data { code = 2, name = "B" },
		new Data { code = 10, name = "C" },
	};
	List<RefCodes> refList = new List<RefCodes>
	{
		new RefCodes { old_code = 1, new_code = 11, new_name = "X" },
		new RefCodes { old_code = 2, new_code = 22, new_name = "Y" }
	};
    Console.WriteLine("Before");
    dataList.ForEach(data => Console.WriteLine(data.code + ": " + data.name));
    Console.WriteLine("");
