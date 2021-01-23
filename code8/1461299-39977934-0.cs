    public class User
    {
	    public string username {get; set;}
	    public string userprincipalname {get; set;}
	    public string status {get; set;}
	    public string status_value
	    {
		    get
		    {
			    return Enum.GetName(typeof(UserStatus), Int32.Parse(this.status));
		    } 
	    }
    }
