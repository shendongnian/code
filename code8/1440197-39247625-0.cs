     [DataContract]
        public class Wrapper
        {
            [DataMember(Name = "data")]
            public Item item { get; set; }
        }
        [DataContract]
        public class Item
        {
            [DataMember(Name = "id")]
            public Guid Id { get; set; }
    
            [DataMember(Name = "item_type")]
            public int? ItemType { get; set; }
    
            [DataMember(Name = "item_name")]
            public string ItemName { get; set; }
        }
