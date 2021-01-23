     using System;
         using System.Text;
            using System.IO;
               using System.Linq;
 
         using System.Text.RegularExpressions;
 
       class Program
       {
         static void Main()
         {
	
        	string input =   "code1,code2,#c55+G35+G97#g,coden,code3,code4,#c44+A25+A07#gcoden";
      string output = Regex.Replace(
        input,
        "(#c(.*?)#g)",
        m => m.Groups[1].Value + Regex.Split(m.Groups[2].Value, @"\+\w").Sum(v => int.Parse(v)) + "#" );
     Console.WriteLine(output);
             
      }
          }
