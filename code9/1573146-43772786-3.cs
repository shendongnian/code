    // This represents the frequency a loan would occur
    public class LoanFrequency
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public LoanFrequency(int id, string value)
        {
            Id = id;
            Value = value;
        }
    }
    // This is a very basic example of a loan
    public class Loan
    {
        public string Name { get; set; }
        public int Frequency { get; set; }
        public Loan(string name, int frequency)
        {
            Name = name;
            Frequency = frequency;
        }
    }
