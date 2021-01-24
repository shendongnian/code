        public class Human
        {
            public int Id { get; set; }
            private string insertedBy;
    
            public string InsertedBy
            {
                get { return insertedBy; }
                set
                {
                    if (string.IsNullOrEmpty(insertedBy))
                    {
                        insertedBy = value;
                    }
                }
            }
            public string Name { get; set; }
        }
