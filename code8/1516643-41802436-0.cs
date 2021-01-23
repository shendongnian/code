	static class Program
	{
		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//program.exe -f c:\\desktop\\1.csv -o c:\\desktop\\1.png
			var inputFile = new List<string>();
			string outputFile = null;
			if (args.Length > 0)
			{
				for (int i = 0; i < args.Length; i++)
				{
					string a = args[i].ToLower();
					switch (a)
					{
						case "-f":
							for (i = i + 1; i < args.Length ; i++)
							{
								string f = args[i]; if (f.StartsWith("-")) break;
								inputFile.Add(f); //get next arg as inputFile
							}
							break;
						case "-o":
							outputFile = args[++i]; //get next arg as outputFile
							break;
					}
				}
				if (inputFile.Count > 0 && outputFile != null)
				{
					//Form2 form = new Form2();
					//form.DoReadFiles(
				}
			}
			else
			{
				Application.Run(new Form2()); //use GUI
			}
			//MessageBox.Show("Args:\r\n" + s);
		}
	}
