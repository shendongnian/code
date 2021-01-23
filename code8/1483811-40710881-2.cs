    public line1 {get; set;}
    public Line3 {get; set;}
    DateTime dateTime;
    int FourDigitYear; 
    int Month; 
    int Day;
    DateTime dateTime;
    Regex Line3 = new Regex(@"(?<one>[0-9]{2}-[0-9]{2}-[0-9]{2})\s{1,20}114B\s{1,15}(?<two>\d{1,11})\s{1,15}(?<three>\d{1,11})\s{1,15}(?<four>\d{1,11})\s{1,30}(?<five>\d{1,11})");//<one> catpures the date data.
    using (StreamReader Reader1 = new StreamReader(@"C:\Users\UK\data.txt"))
    {
       using(StreamWriter Writer1 = new StreamWriter(@"C:\Users\Sample.csv"))
       {
          while((line1 = Reader1.ReadLine())!= null)
          {
            MatchCollection matches = Line3.Matches(line1);
            foreach (Match m in matches)
            {
                 //Writer1.Write(m.Groups["one"].Value + ","); //this line modified with the following.
                 Day = Convert.ToInt32(m.Groups["one"].Value.Substring(0, 2));
                 Month = Convert.ToInt32(m.Groups["one"].Value.Substring(3, 2));
                 FourDigitYear = Convert.ToInt32(m.Groups["one"].Value.Substring(6, 2));
                 FourDigitYear = CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(FourDigitYear);
                 dateTime = new DateTime(FourDigitYear, Month, Day);
                 Writer1.WriteLine(dateTime);
             }
          }
       }
    }
