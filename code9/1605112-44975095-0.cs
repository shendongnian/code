    public class Banana
    {
        public string Text
        {
            get
            {
                return fileContent;
            }
        }
        private static string fileContent;
        static Banana()
        {
            using (var reader = File.OpenText("banana.txt"))
            {
                fileContent = reader.ReadToEnd();
            }
        }
    }
