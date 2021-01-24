	class Compile_Import
	{
		public static string getargs = null;
		public static void CompileAndRun(FileInfo importInfo, string args)
		{
			getargs = args;
			if(importInfo.Extension == ".cbe" && importInfo.Exists)
			{
				using (StreamReader sr = new StreamReader(importInfo.FullName)) //Where my problem occurs.
				{
					string curlinecont = null;
					while((curlinecont = sr.ReadLine()) != null)
					{
						string RawToken = 
					 Parser.Parse.ParseLineIntoToken(Run.Stats.CurrentLineContents);
						Token_Management.Process_Token.ActOnToken(RawToken);
					}
				}
			}
		}
