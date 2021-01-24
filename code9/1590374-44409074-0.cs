    [XmlRoot(ElementName="User")]
    	public class User {
    		[XmlElement(ElementName="UserId")]
    		public string UserId { get; set; }
    		[XmlElement(ElementName="Email")]
    		public string Email { get; set; }
    		[XmlElement(ElementName="UserName")]
    		public string UserName { get; set; }
    		[XmlElement(ElementName="ProfileImage")]
    		public string ProfileImage { get; set; }
    		[XmlElement(ElementName="Name")]
    		public string Name { get; set; }
    		[XmlElement(ElementName="InterestId")]
    		public List<string> InterestId { get; set; }
    		[XmlElement(ElementName="FeedId")]
    		public List<string> FeedId { get; set; }
    		[XmlElement(ElementName="Description")]
    		public List<string> Description { get; set; }
    		[XmlElement(ElementName="Interest")]
    		public List<string> Interest { get; set; }
    	}
    
    	[XmlRoot(ElementName="Users")]
    	public class Users {
    		[XmlElement(ElementName="User")]
    		public List<User> User { get; set; }
    	}
