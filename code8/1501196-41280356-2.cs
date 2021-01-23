    List<Drugs> patients = new List<Drugs>();
    public class Drugs
    {
        public int Dosage { get; set; }
        public string Drug { get; set; }
        public Info Patient { get; set; }
        public DateTime Date { get; set; }
    }
