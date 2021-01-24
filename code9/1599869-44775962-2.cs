    public class User:Java.Lang.Object
    {
        public User() {}
        
        // convert current User to HashMap
        public HashMap ToMap()
        {
            HashMap map = new HashMap();
            map.Put("username", this.username);
            map.Put("email", this.email);
            return map;
        }
        
        public string username;
        public string email;
        public User(string username, string email)
        {
            this.username = username;
            this.email = email;
        }
    }
