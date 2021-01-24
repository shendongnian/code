    public class UserDetails
    {  
        public int User_ID{  
            get;  
            set;  
        }  
        public string User_Name{  
            get;  
            set;  
        }  
        public string User_Email{  
            get;  
            set;  
        }  
       ....
    }  
    string jsonData = "{\'User_ID\':4,\'User_Name\':\'IKERocks\',\'User_Email\':\'bamane1989@gmail.com\'}";
    var myDetails = JsonConvert.DeserializeObject<UserDetails>(jsonData);
