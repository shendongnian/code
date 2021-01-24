    public class Company
    {
        List<string> workers;
        public IReadOnlyCollection<string> Workers
        { 
            get { return workers.AsReadOnly(); }
        }
        // shortened for brevity
    }
