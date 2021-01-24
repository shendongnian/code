    public static void Main(string[] args)
        {
            using (var stream = new StreamReader("sample.json"))
            {
                var rootObject = JsonConvert.DeserializeObject<Root>(stream.ReadToEnd());
                int index = 0;
                foreach (var responses in rootObject.response)
                {
                    Console.WriteLine(responses.stripe_id);
                }
                Console.WriteLine(rootObject.pagination.current);
                Console.WriteLine(rootObject.pagination.next);
                Console.WriteLine(rootObject.pagination.pages);
                Console.WriteLine(rootObject.pagination.per_page);
                Console.WriteLine(rootObject.pagination.previous);
            }
            Console.Read();
        }
