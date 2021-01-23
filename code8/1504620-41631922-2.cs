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
                
                //Email 1
                Personalization emailItem = new Personalization();
                emailItem.Subject = "Hi there Mr %surname%";                
                email = new Email("John.Smith@test.co.za", "John Smith");
                emailItem.AddTo(email);
                emailItem.AddSubstitution("%name%", "John");
                emailItem.AddSubstitution("%surname%", "Smith");
                personal.Add(emailItem);
                //Email 2
                emailItem = new Personalization();
                emailItem.Subject = "Hi there Mr %surname%";                
                email = new Email("Mike.Johns@test.co.za", "Mike Johns");
                emailItem.AddTo(email);
                emailItem.AddSubstitution("%name%", "Mike");
                emailItem.AddSubstitution("%surname%", "Johns");
                personal.Add(emailItem);
                
                mail.Personalization = personal;
                List<Content> contents = new List<Content>();
                Content content = new Content("text/plain", "Is %name% and %surname% your name and surname?");
                contents.Add(content);
                Email from = new Email("no-reply@test.co.za", "Test App");
                string subject = "Testing Sending with SendGrid is Fun, or what do you think %name% %surname%?";
                mail.Subject = subject;
                mail.From = from;
                mail.Contents = contents;
                //Tracking Settings
                TrackingSettings tracking = new TrackingSettings();
                OpenTracking opentracking = new OpenTracking();
                opentracking.Enable = true;
                tracking.OpenTracking = opentracking;
                mail.TrackingSettings = tracking;
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
    
