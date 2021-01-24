    public class User : INotifyPropertyChanged
    {
        public string User_Code { get; set; }
        public string License 
        { 
           get { return _license; }; 
           set 
           {  
               _license = value;
               var handler = PropertyChanged;
               if (handler != null) handler(this, "License");
           } 
        }
        public User_Rank user_Rank { get; set; }
        public User() { }
        public event PropertyChangedEventHandler PropertyChanged;
        
        public User(User u) 
        {
            User_Code = u.User_Code;
            License = u.License;
            user_Rank = u.user_Rank;
        }
    }
