    interface Item {
        public long ID { get; set; }
        public string Name { get; set; }
    }
    
    class SimpleItem : Item {
        public long ID { get; set; }
        public string Name { get; set; }
    }
    
    class ComplicateItem: Item {
        public long ID { get; set; }
        public string Name { get; set; }
        public string AdditionalProperty { get; set; }
    }
