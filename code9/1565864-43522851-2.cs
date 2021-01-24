    public static partial class Program 
	{
		private static string _filePath = "";
		private static string _folderPath = "";
		
		[STAThread]
		static void Main(string[] args)
		{			
			RequestInfo infoForm = new RequestInfo(assignValues);
			DialogResult result = infoForm.ShowDialog();
			if (result.Equals(DialogResult.OK))
			{
				string templPath = _filePath;
				string newPath = _folderPath;
			}
			
			Console.ReadKey(true);
		}
		
		private static void assignValues(string filePath, string folderPath)
		{
			_filePath = filePath;
			_folderPath = folderPath;
		}
	}
