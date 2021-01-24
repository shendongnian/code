         public static DateTime NSDateToDateTime (Foundation.NSDate date)
         {
			DateTime reference = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			var utcDateTime = reference.AddSeconds(date.SecondsSinceReferenceDate);
			return utcDateTime.ToLocalTime();
         }
 
         public static Foundation.NSDate DateTimeToNSDate (DateTime date)
         {
			DateTime reference = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			var utcDateTime = date.ToUniversalTime();
			return Foundation.NSDate.FromTimeIntervalSinceReferenceDate((utcDateTime - reference).TotalSeconds);
         }
