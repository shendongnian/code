    public class MyModel
    {
        public int ID { get; set; }
        public List<int> Numbers { get; set; } // This is the list we're changing
        [Column, ScaffoldColumn(false)]
        public string NumbersStore { get { /*parses Numbers*/ } set { /*splits the value and sets Numbers accordingly*/ } }
    }
