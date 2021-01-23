    using System.Web.Mvc; 
=====================
 
     public class Customer
        {
            //...other fields here
    		 [Remote("ValidateAreaPhoneNumber","Home",AdditionalFields="PhoneNumber",ErrorMessage="Please enter a phone number")]
           
            public string AreaCode { get; set; }
    
            public string PhoneNumber { get; set; }
        }
    	
	
