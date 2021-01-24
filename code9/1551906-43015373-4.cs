    public class Member
    {
        public int Id { get; set; }
		
        public string UserName { get; set; } // to link with Identity
		// some other properties of Member
		public int Age { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
    }
