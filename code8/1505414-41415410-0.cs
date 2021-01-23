    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
         class Program
         {
               static void Main(string[] args)
               {
                    var maskedString  = MaskFileContent(@"C:\PSQL_v10_Install.log", 100, 200);
                    Console.WriteLine(maskedString);
                    Console.ReadKey();
                }
                static string MaskFileContent(string filePath, int indexOfClearData, int lengOfClearData, string mask ="***")
                {
                     int counter = 0;
                     StringBuilder result = new StringBuilder();
  
                     System.IO.StreamReader file =
                                new System.IO.StreamReader(filePath);
                     while (!file.EndOfStream)
                     {
                          var curChar = (char)file.Read();
                          if (counter >= indexOfClearData)
                          {
                              result.Append(curChar.ToString());
                          }
                          if(result.Length >= lengOfClearData)
                               break;
                          counter++;
                    }
                    file.Close();
                    result.Insert(0, mask);
                    result.Append(mask);
                    return result.ToString();
              }
          }
    }
 
