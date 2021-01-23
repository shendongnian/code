        static void Main(string[] args)
        {
            Execute().Wait();           
        }
               
        static async Task Execute()
        {
            try
            {
                string apiKey = "apikey value";
                dynamic sg = new SendGridAPIClient(apiKey);
                //Declare Mail object
                Mail mail = new Mail();               
                //Declare List as Personalization object type 
                List<Personalization> personal = new List<Personalization>();
                //Declare Personalization object to add to List above
                Personalization emailItem = new Personalization();
                emailItem.Subject = "Hi there";
                //Declare List as Email type 
                List<Email> emails = new List<Email>();
                 //Declare Email object to add to List above
                Email email = new Email();
                 
                email = new Email("email1@example.com", "Recipient 1");
                emails.Add(email);
                email = new Email("email2@example.com", "Recipient 2");
                emails.Add(email);
                email = new Email("email3@example.com", "Recipient 3");
                emails.Add(email);
                emailItem.Tos = emails;
                personal.Add(emailItem);
               
                
                mail.Personalization = personal;
                List<Content> contents = new List<Content>();
                Content content = new Content("text/plain", "Test contents");
                contents.Add(content);
                Email from = new Email("no-reply@test.com", "Test App");
                string subject = "Testing Sending with SendGrid is Fun";
                mail.Subject = subject;
                mail.From = from;
                mail.Contents = contents;
              dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Body.ReadAsStringAsync().Result);
                Console.WriteLine(response.Headers.ToString());
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
        }
    
