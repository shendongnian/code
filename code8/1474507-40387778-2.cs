     using System;
        using System.Text;
 
         using System.Text.RegularExpressions;
       class Program
    {
     static void Main()
    {
	
		string strFile4xf = File.ReadAllText(@"a.txt");
        strFile4xf = Regex.Replace(    strFile4xf,     @"(.*?)\r", "$1a\r");
       File.WriteAllText(@"a1.txt", strFile4xf);
        string strFile4xe = File.ReadAllText(@"b.txt");
          strFile4xe = Regex.Replace(    strFile4xe,     @"(.*?)\r", "$1b\r");
       File.WriteAllText(@"b1.txt", strFile4xe);
           	string s4 = File.ReadAllText(@"a1.txt"); 
 
       string s2 = File.ReadAllText(@"b1.txt"); 
      string sn = string.Concat(s4, s2);
      File.WriteAllText(@"join.txt", sn);
      var contents = File.ReadAllLines("join.txt");
           Array.Sort(contents);
        File.WriteAllLines("join.txt", contents);
         string strFile4x = File.ReadAllText(@"join.txt");
       strFile4x = Regex.Replace(    strFile4x,     @"\n(.*?)a\r\n\1b\r", "");
         File.WriteAllText(@"removeequal.txt", strFile4x);
       var contents2 = File.ReadAllLines("removeequal.txt");
           Array.Sort(contents2);
        File.WriteAllLines("removeequal.txt", contents2);
 
    
    string strFile4x2 = File.ReadAllText(@"removeequal.txt");
     strFile4x2 = Regex.Replace(    strFile4x,     @"\n\r", "");
     File.WriteAllText(@"blanklines.txt", strFile4x2);
              
         }
      }
