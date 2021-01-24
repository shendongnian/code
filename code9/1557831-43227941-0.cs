	public static class Helper{
		public static DateTime GetDateTimeAsUtc(this IDataReader reader, string column){
			return DateTime.SpecifyKind((DateTime)reader["reader"], DateTimeKind.Utc);
		}
	}
