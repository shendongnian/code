    void Main()
    {
	    byte[] bytes = System.IO.File.ReadAllBytes(@"C:\temp\test.csv");
	
	    using (var bw = new BinaryWriter(File.Open(@"C:\temp\test2.csv", FileMode.OpenOrCreate)))
        {
		    bw.Write(bytes);
		    bw.Flush();
	    }
	
    }
