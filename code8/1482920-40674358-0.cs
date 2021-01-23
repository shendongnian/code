        private static void GetMessagesInternal() //WORKS FINE
    {
    
        while(true)
        {
           var messages = MyProgram.GetMessages();
        
           foreach (var message in messages)
           {
               Console.WriteLine($"{message.MessageText}");
            }
        }
