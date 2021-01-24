        public class DataModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int America { get; set; }
            public int Japan { get; set; }
            public int Singapore { get; set; }
            public IList<DataModel> Children { get; set; }
            public DataModel()
            {
                Children = new List<DataModel>();
            }
        }
        public class DataMapping
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public int ParentId { get; set; }
        }
