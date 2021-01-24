    using System;
    using Twilio;
    class Example 
    {
      static void Main(string[] args) 
      {
        // Find your Account Sid and Auth Token at twilio.com/user/account
        string AccountSid = "AC81ebfe1c0b5c6769aa5d746121284056";
        string AuthToken = "your_auth_token";
        var twilio = new TwilioRestClient(AccountSid, AuthToken);
    
        var recordings = twilio.ListRecordings(null, null, null, null);
        
        foreach (var recording in recordings.Recordings)
        {
          Console.WriteLine(recording.Duration);
          // Download recording.Uri here
        }
      }
    }
