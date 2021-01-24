    public class Criteria
    {
       [CustomFromQuery(nameof(FirstName))]
       public string FirstName { get; set; }
    }
