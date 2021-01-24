	public class DataAccess
	{
		public ObservableCollection<Facilities> GetFacilities()
		{
			ObservableCollection<Facilities> facilities = new ObservableCollection<Facilities>();
		
			using (MySqlConnection con = new MySqlConnection(dbConnectionString))
			{
				con.Open();
				string Query = "SELECT * FROM facilities";
				MySqlCommand createCommand = new MySqlCommand(Query, con);
				MySqlDataReader dr = createCommand.ExecuteReader();
				int count = 1;
				while (dr.Read())
				{
					string FacilityName = dr.GetString(1);
					facilities facilityname = new Facilities(count, FacilityName);
					facilities.Add(facilityname);
					count++;
				}
				con.Close();
			}
			
			return facilities;
		}
	}
