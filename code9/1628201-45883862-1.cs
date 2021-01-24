        static void Main(string[] args)
        {
            Sender mailSender = new Sender();
            var send1 = mailSender.SendEmailAsync("myemail@gmail.com", "Async mail with attachment", "Async mail with attachment body goes here ...", filePath + "TestFile.txt");
            var send2 = mailSender.SendEmailAsync("anotheremail@gmail.com.com", "Async mail with attachment", "Async mail with attachment body goes here ...", filePath + "TestFile.txt");
            Task.WaitAll(send1,send2);
            File.Delete(filePath + "TestFile.txt");
            Console.WriteLine("Email sent successfully!!!");
            Console.ReadLine();
        }
