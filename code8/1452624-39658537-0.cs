    public class ErrorReporter<TSource, TCode> where TSource : Information<TCode>
    {
        public readonly TSource Info = Activator.CreateInstance<TSource>();
    
        public void Update()
        {
            if (Info.Changed)
            {
                Console.WriteLine(Info.StatusCode.ToString());
                Console.WriteLine(JsonConvert.SerializeObject(Info));
            }
        }
    }
