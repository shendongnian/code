    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO; //for StreamReader and StreamWriter
    using System.Text.RegularExpressions;
    using System.Windows.Forms; 
    using System.Globalization; //from two digit date to four digit date conversion.
    namespace Experiment2
    {
        class DemandRefundOnly
        {
          public line1 {get; set;}
          public Line3 {get; set;}
          DateTime dateTime;
          int FourDigitYear; 
          int Month; 
          int Day;
          DateTime dateTime;
          Regex Line3 = new Regex(@"(?<one>[0-9]{2}-[0-9]{2}-[0-9]{2})\s{1,20}114B\s{1,15}(?<two>\d{1,11})\s{1,15}(?<three>\d{1,11})\s{1,15}(?<four>\d{1,11})\s{1,30}(?<five>\d{1,11})");//Regex to capture data. //<one> catpures the date data.
          //Only the relevant date part is going to be shown in the output given.
          using (StreamReader Reader1 = new StreamReader(@"C:\Users\UK\data.txt"))
          { //StreamREader to read the input text file.
             using(StreamWriter Writer1 = new StreamWriter(@"C:\Users\Sample.csv"))
             { //StreamWriter to wrie to the output file.
                while((line1 = Reader1.ReadLine())!= null)
                { //to loop through the input file.
                   MatchCollection matches = Line3.Matches(line1);
                   foreach (Match m in matches)
                   { //for...each to loop through and print the matches.
                      //Writer1.Write(m.Groups["one"].Value + ","); //this line modified with the following.
                     Day = Convert.ToInt32(m.Groups["one"].Value.Substring(0, 2));
                        //the above captures the first two digits date string contained in m.Groups["one"].Value and stores the first two characters as int to Day.
                     Month = Convert.ToInt32(m.Groups["one"].Value.Substring(3, 2));
                     FourDigitYear = Convert.ToInt32(m.Groups["one"].Value.Substring(6, 2));
                     FourDigitYear = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(FourDigitYear);
                     dateTime = new DateTime(FourDigitYear, Month, Day);
                     Writer1.WriteLine(dateTime);
                   }
                }
             }
          }
       }
    }
