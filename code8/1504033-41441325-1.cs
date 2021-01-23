string path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
    		writeText(et1.Text, "Text1.txt");
		    writeText(et2.Text, "Text2.txt");
		void writeText(string text, string name) {
			 string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			 string filename = Path.Combine(path, name);
			 using(var streamWriter = new StreamWriter(filename, true)) {
			  streamWriter.Write(text);
			 }
		}
