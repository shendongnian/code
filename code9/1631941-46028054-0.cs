    public class Program
    {
        public static void Main()
        {
            string data = File.ReadAllText("MyFilePath");
            //string data = "Afnan is awesome";
            var dictionary = new HashSet<string>();
            for (var stringLengthIncrementer = 1; stringLengthIncrementer <= (data.Length / 2); stringLengthIncrementer++)
            {
                var batched = data.Batch(stringLengthIncrementer);
                foreach (var batch in batched)
                {
                    dictionary.Add(new string(batch.ToArray()));
                }
            }
            Console.WriteLine(dictionary);
            dictionary.ForEach(z => Console.WriteLine(z));
            Console.ReadLine();
        }
    }
