    public class T_User
    {
        [InverseProperty("User")]
        public virtual ICollection<T_Album> userAlbums {get; set;}
        [InverseProperty("Parent")]
        public virtual ICollection<T_Album> parentAlbums {get; set;}
        //other stuff...
    }
    
    public class T_Album
    {
        [ForeignKey("User")]
        public int UserId {get;set;}
        public virtual T_User User {get; set;}
    
        [ForeignKey("Parent")]
        public int ParentId {get;set;}
        public virtual T_User Parent {get; set;}
        //other stuff...
    }
