       static void Main(string[] args)
        {
            string myMessage = "abcd";
            var message = new
            {
                type = "Text",
                text = myMessage
            };
            Console.WriteLine(message.text); //output: abcd
            Console.ReadKey();
        }
