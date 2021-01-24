    class Program
	{
		private static string str1 { get; set; }
		private static string str2 { get; set; }
		private static string str3 { get; set; }
		private static string ConceptOrder { get; set; }
		static void Main(string[] args)
		{
			str1 = "string1";
			str2 = "string2";
			str3 = "string3";
			ConceptOrder = "2, 3, 1";
			Console.WriteLine(ConceptValues(ConceptOrder));
            // output: string2 string3 string1
			Console.ReadKey(true);
		}
    }
