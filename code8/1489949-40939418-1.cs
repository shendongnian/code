    using System;
    using System.Net;
    using RestSharp;
    namespace TestTwilio
    {
        class Program
        {
            static void Main(string[] args)
            {
                var client = new RestClient("https://api.twilio.com/2010-04-01/Accounts/{yourTwilioAccountSID}/SMS/Messages.json");
                client.Proxy = new System.Net.WebProxy("proxy.mycompany.com", 8080);
                client.Proxy.Credentials = new NetworkCredential("<<proxyServerUserName>>", "<<proxyServerPassword>>", "<<proxyServerDomain>>");
                var request = new RestRequest(Method.POST);
                request.Credentials = new NetworkCredential("<<your Twilio AccountSID>>", "<<your Twilio AuthToken>>");
                request.AddParameter("From", "+1xxxxxxxxxx");
                request.AddParameter("To", "+1xxxxxxxxxx");
                request.AddParameter("Body", "Testing from C# after authenticating with a Proxy");
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                Console.ReadKey();
            }
        }
    }
