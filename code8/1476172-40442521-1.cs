    public class Doctor
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public int YderNr { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var doctors = new List<Doctor>
            {
                new Doctor()
                {
                    Name = "Jens Andersen",
                    PhoneNumber = 12345567,
                    YderNr = 02131
                }
            };
            var userInput = int.Parse(txtPraksisoplysningerYderNr.Text);
            var doctor = doctors.SingleOrDefault(d => d.YderNr == userInput);
            if (doctor != null)
            {
                // Set the textbox text with the doctor's data
            }
        }
    }
