    public partial class usertmp
        {
        ...
        [Column("user_first_nametmp")]
        public string FirstName { get; set; }
        [Column("user_last_nametmp")]
        public string LastName { get; set; }
        [Column("user_birth_datetmp")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        ...
        }
