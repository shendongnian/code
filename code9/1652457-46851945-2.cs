    using System.Text.RegularExpressions;
    
    function string cleanMessage(string str)
    {
         string pattern = "([^;]{2}.):(\s[^:]{2})"; 
         //This will be 2 characters that cannot be ':' followed by anything then a ':' followed by a space and 2 more characters that cannot by ':' 
         //For instance, "BNF: :F" would FAIL and not get replaced but "BNF: HH" would pass and become "BNF* HH"
         Regex rgx = new Regex(pattern);
         string replaceResult = rgx.Replace(str,"$1*$2") //this will replace the : with a * 
         return replaceResult;
    }
