    public class Person
    {
        [Key]
        public int Id { get; set; }
        public bool Active {
            get { return Convert.ToBoolean(activeNumeric); }
            set { this.activeNumeric = Convert.ToInt32(value); }
        }
        private int activeNumeric { get; set; }
    }
