    public class FullName
    {
        public  string FirstName { get; set; }
        public  string MiddleName { get; set; }
        public  string LastName { get; set; }
        public FullName()
        {
            
        }
        public FullName(string fullName)
        {
            var nameParts = fullName.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts == null)
            {
                return;
            }
            if (nameParts.Length > 0)
            {
                FirstName = nameParts[0];
            }
            if (nameParts.Length > 1)
            {
                MiddleName = nameParts[1];
            }
            if (nameParts.Length > 2)
            {
                LastName = nameParts[2];
            }
        }
        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName}".TrimEnd();
        }
    }
