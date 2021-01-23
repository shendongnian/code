    using System.ComponentModel.DataAnnotations;
    public bool IsValidEmail(string email)
     {
        return new EmailAddressAttribute().IsValid(email);
     }
        
   
