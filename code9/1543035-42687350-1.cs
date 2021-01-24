    static void sendMail()
    {
       if(IsAuthorized)
       { 
        Console.WriteLine("To address :");
        string toAddress = Console.ReadLine();
        Console.WriteLine("Subject :");
        string subject = Console.ReadLine();
        Console.WriteLine("Message :");
        string messageBody = Console.ReadLine();
        Gmail.sendMail(gmailAddress, gmailPassword, toAddress, subject, messageBody);
        Console.WriteLine("message sent");
    
        }
          else
        {
                   loggingOn();
    
        }
     }
