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
       ....
    }  
    var myDetails = JsonConvert.DeserializeObject <UserDetails> (jsonData); 
