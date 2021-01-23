    public class Info
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public static implicit operator Info(bool b)
		{
			return null;
		}
    }
