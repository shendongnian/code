	System.Windows.Forms.OpenFileDialog oFile = new System.Windows.Forms.OpenFileDialog();
	
	oFile.InitialDirectory = "c:\\" ;
	oFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
	oFile.FilterIndex = 2 ;
	oFile.RestoreDirectory = true ;
	
	if(oFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
	{
		string file = oFile.Filename;
		string tmp = file + ".tmp";
		
		if (System.IO.File.Exists(tmp)) 
			System.IO.File.Delete(tmp);
		
		using(System.IO.StreamReader sr = new System.IO.StreamReader(file)) 
		using(System.IO.StreamWriter sw = new System.IO.StreamWriter(top, false, Encoding.ASCII ))
		{
			string line = null;
			while((line = sr.ReadLine()) != null)
				sw.WriteLine(line.Replace("’", "").Replace("'", ""));
		} 
		
		System.IO.File.Delete(file);
		System.IO.File.Move(tmp,  file);
	}
