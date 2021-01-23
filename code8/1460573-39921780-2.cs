	public class StorePage
	{
		public StorePage(){
			SPAttributeRefID = new List<int>();
			AttributeID = new List<int>();
		}
	   // these are now Lists
		public List<int> SPAttributeRefID { get; set; }
		public List<int> AttributeID { get; set; }
	}
	public StorePage GetPage(int StorePageID, int SPPreambleID)
	{
		StorePage storepage = null;
		using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DEV_BI01_LVT"].ConnectionString))
		using (SqlCommand cmd = new SqlCommand("mn_StorePage_GetPage", con))
		{
			cmd.Parameters.AddWithValue("@StorePageID", SqlDbType.Int).Value = StorePageID;
			if (SPPreambleID != -1)                    
			{
				cmd.Parameters.AddWithValue("@SPPreambleID", SqlDbType.Int).Value = SPPreambleID;
			}
			cmd.CommandType = CommandType.StoredProcedure;
			con.Open();
			
			using(SqlDataReader reader = cmd.ExecuteReader())
			while (reader.Read())
			{
				// create a new instance if not created yet
				if(storepage == null)
				{
					storepage = new StorePage();
					storepage.StorePageID = reader.GetInt32(0);
					storepage.Title = (reader.IsDBNull(1)) ? string.Empty : reader.GetString(1);
					storepage.SEOTitle = (reader.IsDBNull(2)) ? string.Empty : reader.GetString(2);
					storepage.ParentStorePageID = (reader.IsDBNull(3)) ? -1 : reader.GetInt32(3);
					storepage.Meta = (reader.IsDBNull(4)) ? string.Empty : reader.GetString(4);
					storepage.SPPreambleID = (reader.IsDBNull(5)) ? -1 : reader.GetInt32(5);
					storepage.Image = (reader.IsDBNull(6)) ? string.Empty : reader.GetString(6);
					storepage.ImageLink = (reader.IsDBNull(7)) ? string.Empty : reader.GetString(7);
					storepage.Blurb = (reader.IsDBNull(8)) ? string.Empty : reader.GetString(8);
					storepage.RegionID = (reader.IsDBNull(9)) ? -1 : reader.GetInt32(9);
					storepage.Footer = (reader.IsDBNull(10)) ? string.Empty : reader.GetString(10);
				}
				// only read the columns 12,13 and add each respective member to the corresponding list
				if(!reader.IsDBNull(11))
					storepage.SPAttributeRefID.Add(reader.GetInt32(11));
				if(!reader.IsDBNull(12))
					storepage.AttributeID.Add(reader.GetInt32(12));
			}
		}
		return storepage;
	}
