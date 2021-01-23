	public static  void CreateFile(this List<T> lines, File_attribute fa) where T : ILine
	{
		 using (System.IO.StreamWriter file = new System.IO.StreamWriter(System.IO.Path.Combine(fa.OutpoutFolder, fa.FileName)))
		 {
			 foreach (ILine line in lines)
			 {
				 file.WriteLine(lin.GetLineOutput());
			}
		 }
	}
