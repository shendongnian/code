	void Main()
	{
		string name = String.Join("", new [] { "Ja", "ck" });
		Console.WriteLine(String.IsInterned(name));
	}
