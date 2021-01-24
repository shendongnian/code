    using System.Text.RegularExpressions;
    
    function string cleanMessage(string str)
    {
         string pattern = ":(\s)"; //This will be a ':' followed by a space
         Regex rgx = new Regex(pattern);
         string replaceResult = rgx.Replace(str,"*$1") //this will replace the pattern with a '*' followed by a space. 
         return replaceResult;
    }
