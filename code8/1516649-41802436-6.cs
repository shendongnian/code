	static class Program
	{
        [System.Runtime.InteropServices.DllImport("kernel32.dll")] // ### Edit 3 ###
        static extern bool AttachConsole(int dwProcessId); // ### Edit 3 ###
		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		static void Main(string[] args)
		{
            // redirect console output to parent process;
            // must be before any calls to Console.WriteLine()
            AttachConsole(-1);// ### Edit 3 ###
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
								string f = args[i]; if (f.StartsWith("-")) { i--; break; }
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
					var form = new Form2(); //specify your form class
                    form.showErrorsInConsole = true; // ### Edit 3 ###
					//form.Visible = true;
					form.DoReadFiles(inputFile.ToArray());
					form.DoPlot();
					form.SavePic(outputFile);
					form.Dispose();
					return;
				}
			}
			//else
			Application.Run(new Form2()); //show GUI
			//MessageBox.Show("Args:\r\n" + s);
		}
	}
