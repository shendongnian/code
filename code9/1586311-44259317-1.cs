    namespace Domain
    {
        public class Country : BaseModel
        {
            [Index(IsUnique = true)]
            public string Name { get; set; }
        }
    }
