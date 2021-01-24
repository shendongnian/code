    	public static bool saveToFile(DataTable[] NW, string path)
		{
			
			try
			{
				var NWDS = new DataSet();
				foreach (DataTable dt in NW) {
					NWDS.Tables.Add(dt.Copy());
				}
				NWDS.WriteXml(File.Create(path));
				return true;
			}
			catch(Exception ex)
			{
				MessageBox.Show("ERROR" + Environment.NewLine + ex.Message);
				return false;
			}
		}
   		public static DataTable[] loadFromFile(string path)
		{
			try
			{
				var NWDS = new DataSet();
				NWDS.ReadXml(File.Open(path,FileMode.Open));
				var NW = new DataTable[15];
				NWDS.Tables.CopyTo(NW,0);
				return NW;
				
			}
			catch(Exception ex)
			{
				MessageBox.Show("ERROR" + Environment.NewLine + ex.Message);
				return null;
			}
		}
