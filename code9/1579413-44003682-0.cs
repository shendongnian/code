    public class MyObject 
    {
        public int? ID { get; set; }
        public string ObjectType { get; set; }
        public string Content { get; set; }
        public string PreviewContent { get; set; }
    
        public static void SaveList(List<MyObject> lst)
        {
            using (DBConnection connection = new DBConnection())
            {
                if (connection.Connection.State != ConnectionState.Open)
                    connection.Connection.Open();
    
                connection.Connection.Execute("INSERT INTO [MyObject] (Id, ObjectType, Content, PreviewContent) VALUES(@Id, @ObjectType, @Content, @PreviewContent)", lst);                
            }
        }
    }
