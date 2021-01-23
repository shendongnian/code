    public class UserDetailLanguage
    {
        public Int32 Id { get; set; }
        public virtual UserDetail UserDetail { get; set; }
        public Int32 UserDetailId { get; set; }
    	
        public virtual Language Language { get; set; }
        public Int32 LanguageId { get; set; }
    	
    	public Boolean IsKnown { get; set; }
    }
    public class UserDetail
    {
        ...
        public virtual ICollection<UserDetailLanguage> UserDetailLanguages { get; set; }
        ...
    }
    public class Language
    {
        ...
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    	
        public virtual ICollection<UserDetailLanguage> UserDetailLanguages { get; set; }
        ...
    }
