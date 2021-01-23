    using System;
    using System.Text.RegularExpressions;
    
    class MainClass {
      public static void Main (string[] args) {
      	string ss="Dear Ankit, pls verify your profile on www.abcd.com with below login details: User ID : 123 Password: 123 Team- abcd";
     
            Regex Re = new Regex(@"^Dear (\S+), pls verify your profile on www\.abcd\.com with below login details: User ID : (\S+) Password: (\S+) Team- abcd$");
    
            if(Re.IsMatch(ss))
            {
               Console.WriteLine ("Matched!!!");
            }
            else
            {
                Console.WriteLine ("Not Matched!!!");
            }
      }
    }
          
