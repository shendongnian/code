    public class FileWriter
    {
        private readonly TextWriter _console;
    
        public FileWriter(TextWriter console)
        {
            _console = console;
        }
    
        public void WriteToOutput(List<Person> list)
        {
            string outputFileName = "names-list.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(outputFileName, false))
                {
                    foreach (var item in list)
                    {
                        sw.WriteLine(item.GivenNames + " " + item.LastName);
                        _console.WriteLine(item.GivenNames + " " + item.LastName); //writting names to console
                    }
                    _console.WriteLine("Press Enter to Exit...");
                    sw.Close();
                }
    
            }
            catch (NullReferenceException ex)
            {
                _console.WriteLine("List is Empty");
            }
    
        }
    }
