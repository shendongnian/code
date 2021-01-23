	private static List<PropertyInfo> hotelImages = GetHotelImageProperties();
	private static List<PropertyInfo> GetHotelImageProperties()
	{
		return typeof(Hotel)
			.GetProperties(BindingFlags.Instance | BindingFlags.Public)
			.Where(x => x.PropertyType == typeof(Image))
			.Where(x => x.CanRead)
			.Where(x => x.Name.StartsWith("Image"))
			.ToList();
	}
