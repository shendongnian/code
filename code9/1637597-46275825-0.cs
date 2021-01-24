    public   IEnumerable<Users> GetAll()
        {
    
                var conn = GetOpenConnection();
               IEnumerable<Users> data = conn.Query<Users>("SELECT * FROM arabaicsms.users  "); // error happens here 
                ConnectionClose();
    
            return data;
        }
