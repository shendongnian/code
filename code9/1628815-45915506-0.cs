    using Google.Apis.Gmail.v1;
    using Google.Apis.Gmail.v1.Data;
    
    // ...
    
    public class MyClass {
    
      // ...
    
      /// <summary>
      /// Send an email from the user's mailbox to its recipient.
      /// </summary>
      /// <param name="service">Gmail API service instance.</param>
      /// <param name="userId">User's email address. The special value "me"
      /// can be used to indicate the authenticated user.</param>
      /// <param name="email">Email to be sent.</param>
      public static Message SendMessage(GmailService service, String userId, Message email)
      {
          try
          {
              return service.Users.Messages.Send(email, userId).Execute();
          }
          catch (Exception e)
          {
              Console.WriteLine("An error occurred: " + e.Message);
          }
    
          return null;
      }
    
      // ...
    
    }
