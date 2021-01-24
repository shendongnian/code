        [DataContract]
        public class City
        {	
            [DataMember]
            public string CityN {get;set;}
        	
        	[DataMember]
        	public int CityID {get;set;}
        }
        
        [ServiceContract]
        public interface ICities
        {
           [OperationContract]
           List<City> GetAllCities();
        }
        
        public class PhBookService : ICities
        {
        	 public List<City> GetAllCities()
        	{
        		List<Cities> listCity = new List<Cities>();
        
        		SqlConnection connection = new SqlConnection("Data Source=BS-HP-PC-11\\SQLEXPRESS;Initial Catalog=PhoneBookData; Integrated Security=true; User ID=phonebook;Password=phone");
        		using (connection)
        		{
        			SqlCommand command = new SqlCommand("select * from d_City", connection);
        			connection.Open();
        			SqlDataReader reader = command.ExecuteReader();
        			while (reader.Read())
        			{
        				Cities City = new Cities();
        				City.CityID = Convert.ToInt32(reader["CityID"]);
        				City.CityN = reader["CityN"].ToString();
        				listCity.Add(City);
        			}
        		}
        		
        		return listCity;
        	}
        }
