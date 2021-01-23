    public class ErrorReporter<T>
    {
        // You could expose this as a property if you want. I would
        // advise against exposing it as a field
        private readonly Information<T> source;
        public ErrorReporter(Information<T> source)
        {
            this.source = source;
        }
    
        public void Update()
        {
            if (Info.Changed)
            {
                Console.WriteLine(source.StatusCode.ToString());
                Console.WriteLine(JsonConvert.SerializeObject(source));
            }
        }
    }
