		public string[] section { get; private set; } // ***
		public Read(Stream myStream)
		{
			string aux;
			string[] pieces;
			//read the file line by line
			StreamReader sr = new StreamReader(myStream);
			aux = sr.ReadLine();
			header = aux.Split(',');
			nColumns = header.Length;
			nLines = 0;
			while ((aux = sr.ReadLine()) != null)
			{
				if (aux.Length > 0) nLines++;
			}
			//read the numerical data from file in an array
			data = new float[nLines, nColumns - 1]; // *** last column is sectionName
			section = new string[nLines]; // *** 
			sr.BaseStream.Seek(0, 0);
			sr.ReadLine();
			for (int i = 0; i < nLines; i++)
			{
				aux = sr.ReadLine();
				pieces = aux.Split(',');
				for (int j = 0; j < nColumns; j++)
				{
					if (j < nColumns - 1) // *** this if is new
						data[i, j] = float.Parse(pieces[j]);
					else
						section[i] = pieces[j];
				}
			}
			sr.Close();
		}
		public string[] get_Header() { return header; }
		public float[,] get_Data() { return data; }
		public int get_nLines() { return nLines; }
		public int get_nColumns() { return nColumns; }
	}
