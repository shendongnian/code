    [Route("api/test")]
    public string Post(myData model)
    {
        return String.Format("{0} {1:d}", model.FirstName, model.LastName);
    }
    
    public class myData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
