    public class RequestValidator
    {
	    public bool IsValid(HttpRequest request)
	    {
		   bool isValid  = false;
		
		   //TODO: Intitialize your userService here, may be using DI or a concrete object creation depending on your implementation
		
           var auth = request.Headers["Authorization"];
           if (!string.IsNullOrEmpty(auth))
           {
               var cred = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
               var user = new { Name = cred[0], Password = cred[1] };
            
			   isValid = userService.AuthorizeTutor(user.Name, user.Password))            
           }
		
          return isValid; 
     	}
    }
