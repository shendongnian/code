        static void Main(string[] args)
        {
            var messages = new TagDictionary();
            messages.Add(new string[] { "greeting", "hello", "hei", "hi" }, "Hello!");
            messages.Add(new string[] { "greeting", "bye", "buh-bye", "sayonara" }, "Bye!");
            foreach (var value in messages.GetValuesByTags(new[] { "greeting", "hello" }))
            {
                Console.WriteLine(value);
            }
        }
