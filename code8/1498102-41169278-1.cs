		IEnumerable<Test> cast = data.Cast<Test>();
		IEnumerable<Test> select = data.Select(e => (Test) e);
		Console.WriteLine(cast == (IEnumerable<int>) data); //True
		Console.WriteLine(select == (IEnumerable<int>) data); //False
		Console.WriteLine(select == cast); //Flase
