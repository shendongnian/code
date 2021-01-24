    namespace Model
    {
        public class User
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string State { get; set; }
            public List<Case> Cases { get; set; }
        }
    }  
