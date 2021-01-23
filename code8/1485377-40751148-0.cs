	public class RowKey
	{
		public string Title { get; set; }
		public int Id { get; set; }
        public RowKey()
        {
        }
        public RowKey(string title, int id)
        {
            Title = title;
            Id = id;
        }
		
		public override bool Equals(object obj)
		{
			if (!(obj is RowKey))
				return false;
	
			RowKey other = obj as RowKey;
			return Title.Equals(other.Title) && Id.Equals(other.Id);
		}
		public override int GetHashCode()
		{
			int titleHash = Title.GetHashCode();
			int idHash = Id.GetHashCode();
	
			return (((titleHash << 5) + titleHash) ^ idHash);
		}
	}
