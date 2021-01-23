    using System;
        class MainClass {
          public static void Main (string[] args) {
            var stringWithSpecialChar1 = "/Home%";
            var stringWithSpecialChar2 = "/%";
            bool ans = checkIfStringIsPresent(stringWithSpecialChar1);
            Console.WriteLine(ans);
            ans = checkIfStringIsPresent(stringWithSpecialChar2);
            Console.WriteLine(ans);
          }
          public static bool checkIfStringIsPresent(string s){
            var len = s.Length;
            if(s[0]!='/' || s[len-1]!='%')
              return false; // if string doesn't start and and with correct symbols, then return false
            var i = 0;
            for(i=1;i<len-1;i++){
              return true; // something is present in between / and %, so return true
            }
            return false; // else return false
          }
        }
