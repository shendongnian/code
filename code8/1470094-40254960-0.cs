    [DataContract]
    class SuperWrapper {
        private List<int> _myList;
        private string _name;
        [DataMember]
        public List<int> Items { get { return _items; } set { _items = value; } }
        [DataMember]
        public string Name { get { return _name; } set { _name = value; } }
    }
