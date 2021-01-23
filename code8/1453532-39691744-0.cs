	public class Factory 
	{
		public HotelVm Create(Hotel h)
		{
			return new HotelVm()
			{
				HotelName = h.HotelName, 
				CityName = h.City.CityName, 
				CountryName = h.City.Country.CountryName
			}
		}
	}
