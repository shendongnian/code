    public partial class Subject
    {
        private int v;
        private int userid;
       
        public Subject()
        {
        }
        public Subject(int v, int userid, string name)
        {
            this.class_id = v;
            this.user_id = userid;
            this.name = name;
        }
    
    
        public int class_id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Subjects_Users Subjects_Users { get; set; }
        public virtual Task Task { get; set; }
    }
