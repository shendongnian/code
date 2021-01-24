    public class FileWriter
    {
        public Action<string> Log { get; set; }
        public void WriteToOutput(List<Person> list)
        {
            ...
            Log("List is Empty");
        }
    }
