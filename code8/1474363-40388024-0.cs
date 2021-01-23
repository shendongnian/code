    public static class Ext
    {
	
        public static DateTime? SpecialDate(this DateTime? v)
	    {
	        if (!v.HasValue) return null;
	        return new DateTime(v.Value.Year, 1, 1);
        }
	
	    public static DateTime? SpecialDate2(this DateTime? v)
	    {
	        if (!v.HasValue) return null;
		    // neither this
            return new DateTime().AddYears(v.Value.Year - 1);
		    // or this - uses parameterized constructor
            //return DateTime.MinValue.AddYears(v.Value.Year - 1);
	    }
    }
