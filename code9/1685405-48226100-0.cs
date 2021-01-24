    public class UserItem
    {
        [Key]
        public int matrikelnr { get; set; }
        public string studiengang { get; set; }
        public string user_semester { get; set; }
        public string user_max_klausur { get; set; }
        //Not necessary Constructor. I try to fix the primary Key error.
        public UserItem()
        {
            this.matrikelnr = 0;
            this.studiengang = "";
            this.user_max_klausur = "";
            this.user_semester = "";
        }
    }
