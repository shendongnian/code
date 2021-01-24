    class BoundDataObject
    {
        public DateTime Field1 { get; set; }
        public short Field2 { get; set; }
        public bool PassFail
        {
            get { return Field1 < DateTime.Now.AddDays(Field2); }
        }
    }
