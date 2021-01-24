    // Your data object
    public class ClassInfo
	{
		public string Class { get; set; }
		public string Semester { get; set; }
		public DateTime Due { get; set; }
		public string Importance { get; set; }
	}
    // something that takes care of the update
    public interface IDatabase
    {
        void SendClassInfoUpdate(ClassInfo ci);
    }
    // a thin wrapper
    public class ClassInfoViewModel
    {
        IDatabase _db;
        ClassInfo _ci;
        public ClassInfoViewModel(IDatabase db, ClassInfo ci)
        {
            _db = db;
            _ci = ci;
        }
		public string Class
        {
            get => _ci.Class;
            set => _ci.Class = value;
        }
		public string Semester
		{
			get => _ci.Semester;
			set => _ci.Semester = value;
		}
		public DateTime Due
		{
			get => _ci.Due;
            set
            {
                _ci.Due = value;
                _db.SendClassInfoUpdate(_ci);
            }
		}
		public string Importance
		{
			get => _ci.Importance;
			set => _ci.Importance = value;
		}
	}
