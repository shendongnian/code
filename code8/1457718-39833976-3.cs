	[Serializable]
	public partial class Practice
	{
		public int PracticeKey { get; set; }                   
		public string PracticeName { get; set; }                   
	}
	[Serializable]
	public class PracticeCollection : ICollection<Practice>
	{
	}   
	internal static class PracticeDefaultLayout
	{
		public static readonly int PRACTICE_KEY = 0;
		public static readonly int PRACTICENAME = 1;
	}
	public class PracticeSerializer
	{	
	
		public PracticeCollection SerializeCollection(IDataReader dataReader)
		{
			Practice item = new Practice();
			PracticeCollection returnCollection = new PracticeCollection();
			try
			{
				int fc = dataReader.FieldCount;//just an FYI value
				int counter = 0;//just an fyi of the number of rows
				while (dataReader.Read())
				{
					if (!(dataReader.IsDBNull(PracticeSearchResultsLayouts.PRACTICE_KEY)))
					{
						item = new Practice() { PracticeKey = dataReader.GetInt32(PracticeSearchResultsLayouts.PRACTICE_KEY) };
						if (!(dataReader.IsDBNull(PracticeSearchResultsLayouts.PRACTICENAME)))
						{
							item.PracticeName = dataReader.GetString(PracticeSearchResultsLayouts.PRACTICENAME);
						}
						returnCollection.Add(item);
					}
					counter++;
				}
				return returnCollection;
			}
			//no catch here... see  http://blogs.msdn.com/brada/archive/2004/12/03/274718.aspx
			finally
			{
				if (!((dataReader == null)))
				{
					try
					{
						dataReader.Close(); /* very important */ /* note, if your datareader had MULTIPLE resultsets, you would not close it here */
					}
					catch
					{
					}
				}
			}
		}
	}
	
	
	
	
	
	
	
    	
    namespace MedicalOffice
    {
        public class PracticeDataLayer
        {
            public ICollection<Practice> GetAllPractices()
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = GetConnectionString();
                    cn.Open(); 
    
                    using (SqlCommand cmd = new SqlCommand("SelectPracticeID"))
                    {
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        IDataReader idr = cmd.ExecuteReader();
    					return new PracticeSerializer().SerializeCollection(idr);
    					////  idr.Close(); /* very important, currently the serializer closes it..so commented out here */  /* note, if your datareader had MULTIPLE resultsets, you would close the datareader AFTER you used all the resultsets */
                    }
                }
            }
    
            private string GetConnectionString()
            {
                string conString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                return conString;
            }
        }
     }	
    	
	
