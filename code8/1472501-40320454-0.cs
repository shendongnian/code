    using System;
    using Microsoft.VisualBasic.FileIO;
    class Program
    {
    static void Main()
    {
	using (TextFieldParser parser = new    TextFieldParser("C:\\csv.txt"))
	{
	    parser.Delimiters = new string[] { " " };
	    while (true)
	    {
		string[] parts = parser.ReadFields();
		if (parts == null)
		{
		    break;
		}
		Console.WriteLine("{0} field(s)", parts.Length);
	    }
	}
    }
    }
