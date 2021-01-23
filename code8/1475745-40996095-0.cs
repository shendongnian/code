    public class Employee
    {
        public Employee(string fullName)
        {
            FullName = fullName;
        }
        public string FullName { get; }
    }
    public class Certifying
    {
        public Certifying(string certifyingAuthor, DateTime certifyingDate)
        {
            CertifyingAuthor = certifyingAuthor;
            CertifyingDate = certifyingDate;
        }
        public string CertifyingAuthor { get; }
        public DateTime CertifyingDate { get; }
    }
