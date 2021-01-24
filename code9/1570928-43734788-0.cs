    using System;
    using System.Threading.Tasks;
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Your Account SID from twilio.com/console
                var accountSid = "AC81ebfe1c0b5c6769aa5d746121284056";
                // Your Auth Token from twilio.com/console
                var authToken = "auth_token";   
    
                TwilioClient.Init(accountSid, authToken);
    
                var message = MessageResource.Create(
                    to: new PhoneNumber("+15558675309"),
                    from: new PhoneNumber("+15017250604"),
                    body: "Hello from C#");
    
                Console.WriteLine(message.Sid);
                Console.Write("Press any key to continue.");
                Console.ReadKey();
            }
        }
    }
