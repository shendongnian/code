		private void Form1_Load(object sender, EventArgs e)
		{
			var path = Environment.CurrentDirectory;
			List<String> lines = new List<string>();
			DirectoryInfo d = new DirectoryInfo(path);
			var dir = d.GetDirectories();
			var files = d.GetFiles();
			lines.Add(String.Format("There are {0} directories in \"{1}\"", dir.Length, d.Name));
			lines.Add(String.Format("There are {0} files in \"{1}", files.Length, d.Name));
			foreach (var di in dir)
			{
				lines.Add(String.Format("There are {0} directories in \"{1}\"", dir.Length, d.Name));
				files = di.GetFiles();
				lines.Add(String.Format("There are {0} files in \"{1}", files.Length, d.Name));
			}
			textBox1.Lines = lines.ToArray();
		}
