    using System;
    using System.Text.RegularExpressions;
    
    class MainClass {
     
      public static void Main (string[] args) {
        // valid 16 digit
        string citizenID = "1000.1170. 1000.3826";
        // not valid more than 16 digit
        //string citizenID = "1000.1170. 1000.3826789";
        citizenID = Regex.Replace(citizenID, @"[^\d]", ""); 
        Match match = Regex.Match(citizenID, @"^\d{16}$");
        if(match.Success)
          Console.WriteLine ("valid citizenID: " + citizenID);
        else
          Console.WriteLine ("not valid citizenID");
      }
    }
