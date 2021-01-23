    using System.Diagnostics;
    using System.Text.RegularExpressions;
    
    namespace MrB
    {
        class Program
        {
            static void Main()
            {
                string s1 = "stringVar1  =   \"stringVar1Value\"    and boolVar1<>False or intVar1=22 and    intVar2=33";
                string s2 = "stringVar1=  \"stringVar1Value\" and boolVar1<>False or intVar1=22 and intVar2=33";
                string s3 = "stringVar1  =   \"stringVar1Value\"    and boolVar1<>False or intVar1=22 and    intVar2=33";
    
                var rgx = new Regex("=");
                var replacement = " = ";
    
                string s1b = rgx.Replace(s1, replacement);
                string s2b = rgx.Replace(s2, replacement);
                string s3b = rgx.Replace(s3, replacement);
    
                rgx = new Regex(@"\s+");
                replacement = " ";
    
                string s1c = rgx.Replace(s1b, replacement);
                string s2c = rgx.Replace(s2b, replacement);
                string s3c = rgx.Replace(s3b, replacement);
    
                string[] s1List = s1c.Split(' ');
                string[] s2List = s2c.Split(' ');
                string[] s3List = s3c.Split(' ');
    
                Debugger.Break();
            }
        }
    }
