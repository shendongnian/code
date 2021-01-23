                string apiKey = "your apikey value";
                dynamic sg = new SendGridAPIClient(apiKey);
                Mail mail = new Mail();
                Email email = new Email();
                List<Personalization> personal = new List<Personalization>();
                
                //Email 1
                Personalization emailItem = new Personalization();
                emailItem.Subject = "Hi there Mr %surname%";                
                email = new Email("example@example.co.za", "Example User");
                emailItem.AddTo(email);
                emailItem.AddSubstitution("%name%", "Name");
                emailItem.AddSubstitution("%surname%", "Surname");
                personal.Add(emailItem);
                //Email 2
                emailItem = new Personalization();
                emailItem.Subject = "Hi there Mr %surname%";                
                email = new Email("Example@example.co.za", "Example User");
                emailItem.AddTo(email);
                emailItem.AddSubstitution("%name%", "Name");
                emailItem.AddSubstitution("%surname%", "Surname");
                personal.Add(emailItem);
                
                mail.Personalization = personal;               
                Email from = new Email("no-reply@example.co.za", "My Test App");
                string subject = "Testing Sending with SendGrid is Fun, or what do you think %name% %surname%?";
                mail.Subject = subject;
                mail.From = from;
