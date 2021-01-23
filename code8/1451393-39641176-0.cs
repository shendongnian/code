    using(Pop3 pop3 = new Pop3())  
     {  
         pop3.Connect("server");  
         pop3.UseBestLogin("user", "password");  
         foreach (string uid in pop3.GetAll())  
         {  
             IMail email = new MailBuilder()
             .CreateFromEml(pop3.GetMessageByUID(uid));  
             Console.WriteLine(email.Subject);  
             // save all attachments to disk  
             email.Attachments.ForEach(mime => mime.Save(mime.SafeFileName));  
         }  
         pop3.Close();  
     } 
