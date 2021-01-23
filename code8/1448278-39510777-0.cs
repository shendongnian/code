      using Google.Apis.Gmail.v1;
     using Google.Apis.Gmail.v1.Data;
     // ...
     public class MyClass {
       // ...
     /// <summary>
     /// Retrieve a Message by ID.
     /// </summary>
     /// <param name="service">Gmail API service instance.</param>
     /// <param name="userId">User's email address. The special value "me"
     /// can be used to indicate the authenticated user.</param>
     /// <param name="messageId">ID of Message to retrieve.</param>
     public static Message GetMessage(GmailService service, String userId, String messageId)
     {
         try
         {
             return service.Users.Messages.Get(userId, messageId).Execute();
         }
         catch (Exception e)
         {
             Console.WriteLine("An error occurred: " + e.Message);
         }
         return null;
     }
     // ...
    }
