    public class Employee
    {
        [DateRange(1900, -1, 0, 0, 0, 0)]
        public DateTime? OriginalDocumentDate { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee() { OriginalDocumentDate= DateTime.Now };
            List<ValidationResult> validationResults = new List<ValidationResult>();
            var vc = new ValidationContext(e, null, null);
            var isValid = Validator.TryValidateObject
                    (e, vc, validationResults, true);
        }
    }
