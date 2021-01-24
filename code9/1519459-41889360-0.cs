    String myProject = "Name of your project";
    String file = "Name of your file to extract";
    String outputPath = @"c:\path\to\your\output";
    
    using (System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(myProject + ".Resources." + file))
    {
    	using (System.IO.FileStream fileStream = new System.IO.FileStream(outputPath + "\\" + file, System.IO.FileMode.Create))
        {
    		for (int i = 0; i < stream.Length; i++)
            {
    			fileStream.WriteByte((byte)stream.ReadByte());
            }
            fileStream.Close();
        }
    }
