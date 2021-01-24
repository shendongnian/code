    using System;
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;
    using TwilioSendMulti;
    
    namespace TwilioSendMulti
    {
        public class Program
        {
    
            static void Main(string[] args)
            {
                
               const string accountSid = "put account Sid Here or use class variable";
 
               const string authToken = "put auth Token Here or use class variable";
    
               string[] MultiNums = { "+1212number1", "+1212number2" };
               
               for (int i = 0; i < MultiNums.Length; i++)
                {
                    TwilioClient.Init(accountSid, authToken);
                    var message = MessageResource.Create(
                    body: "Sent thru an Array in C# with Twilio!",
                    from: new Twilio.Types.PhoneNumber("+1212mytwilio#"),
                    to: new Twilio.Types.PhoneNumber(MultiNums[i]));
                    Console.WriteLine(message.Sid);   
                }
                Console.ReadLine();
            }
        }
    }
