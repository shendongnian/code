    var a = "***** ABCDEFGEF 04/28/2017 14:48:40 *****";
    var content = a.Substring(6, a.Length-32);
    var datestring = a.Substring(a.Length-25).Replace("*","");
    		
    		
    Console.WriteLine(content);
    Console.WriteLine(datestring);
