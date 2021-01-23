    class ReadFile
    {
        public double[] ReadFromFile()
        {
			List<double> listaDouble = new List<double>();
			
			using(var file = new System.IO.StreamReader(@"E:\XXXX.csv"))
			{
				string line = "";
				while ((line = file.ReadLine()) != null)
				{
					string[] linetokens = line.Split(',');
					
					listaDouble.AddRange(linetokens.Select (l => double.Parse(l)));
				}
			}
            return listaDouble.ToArray();
        }
    }
