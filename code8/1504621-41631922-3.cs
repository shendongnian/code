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
                Mail mail = new Mail();
                Email email = new Email();
                List<Personalization> personal = new List<Personalization>();
                
                Personalization emailItem = new Personalization();
                emailItem.Subject = "Hi there";
                List<Email> emails = new List<Email>();
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
    
