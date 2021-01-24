       public void Test()
       {
    	   MyCookie = Request.Cookies["ubasubasket"];
    	   //Grab all values for single cookie into an object array.
    	   String[] arr2 = MyCookie.Values.AllKeys;
    
    	   //Loop through cookie Value collection and print all values.
    	   for (loop2 = 0; loop2 < arr2.Length; loop2++) 
    	   {
    		  Response.Write("Value" + loop2 + ": " + Server.HtmlEncode(arr2[loop2]) + "<br>");
    	   }
       }
