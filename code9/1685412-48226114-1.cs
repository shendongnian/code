    // Need to add the following using as well at the top of the file:
    using System.ComponentModel.DataAnnotations;
    public class UserItem
    {
        [Key]
        public int matrikelnr { get; set; }
        public string studiengang { get; set; }
        public string user_semester { get; set; }
        public string user_max_klausur { get; set; }
        // ...
    }
