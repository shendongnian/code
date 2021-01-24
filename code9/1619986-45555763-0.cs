    [Serializable]
    public class Customer
    {
        [ChoCSVRecordField(1)]
        [Key]
        public int Id { get; set; }
        [ChoCSVRecordField(2)]
        public string Street { get; set; }
        [ChoCSVRecordField(4)]
        public string City { get; set; }
        [ChoCSVRecordField(6)]
        public string Zip { get; set; }
    }
