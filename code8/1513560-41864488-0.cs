    public static class PersonViewExtensions
    {
    	const string NameAndOnePhoneFormat="{0} ({1})";
    	public static string NameAndOnePhone(this Person person)
    	{
    		var phone = person.MobilePhone ?? person.HomePhone ?? person.WorkPhone;
    		return string.Format(NameAndOnePhoneFormat, person.Name, phone);
    	}
    }
