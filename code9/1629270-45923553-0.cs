    while (myInt <= 4)
        {      
            string message = "Hello World!";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish("", "test", null, body);
            Console.WriteLine(" [x] Sent {0}", message);
            Console.Read();
            myInt++;
        }
