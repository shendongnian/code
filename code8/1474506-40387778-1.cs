     using System;
        using System.Text;
 
         using System.Text.RegularExpressions;
       class Program
    {
     static void Main()
    {
	
	string s4 = File.ReadAllText(@"a.txt"); 
    string s2 = File.ReadAllText(@"b.txt"); 
        string sn = string.Concat(s4, s2);
       File.WriteAllText(@"join.txt", sn);
       var contents = File.ReadAllLines("join.txt");
    Array.Sort(contents);
    File.WriteAllLines("join.txt", contents);
     string strFile4x = File.ReadAllText(@"join.txt");
          strFile4x = Regex.Replace(    strFile4x,     @"\n(.*?)\r\n\1\r", "");
      File.WriteAllText(@"removeequal.txt", strFile4x);
    var contents2 = File.ReadAllLines("removeequal.txt");
       File.WriteAllLines("removeequal.txt", contents2);
         
     string strFile4x2 = File.ReadAllText(@"removeequal.txt");
      strFile4x2 = Regex.Replace(    strFile4x,     @"\n\r", "");
        File.WriteAllText(@"blanklines.txt", strFile4x2);
              
         }
     }
