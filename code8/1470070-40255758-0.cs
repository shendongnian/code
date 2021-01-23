      class StringComparer : IComparer<string>
      {
        const string pattern = @"^\D*(?<year>\d{4})( \/[MQ](?<index>\d+))?$";
    
        public int Compare(string x, string y)
        {
          var mx = Regex.Match(x, pattern);
          var my = Regex.Match(y, pattern);
    
          int ix;
          if (int.TryParse(mx.Groups["index"].Value, out ix))
          {
            int iy;
            if (int.TryParse(my.Groups["index"].Value, out iy))
            {
              return ix.CompareTo(iy);
            }
          }
    
          return mx.Groups["year"].Value.CompareTo(my.Groups["year"].Value);
        }
      }
    
      class Program
      {
        static void Main(string[] args)
        {
 
          List<string> a = new List<string>();
    
          a.Add("2015");
          a.Add("2015 /Q1");
          a.Add("CY2015 /Q2");
          a.Add("2015 /Q9");
          a.Add("2015 /Q10");
          a.Add("2015 /Q11");
          a.Add("2015 /Q12");
          a.Add("2015 /Q3");
          a.Add("2014");
          a.Add("2015 /Q4");
          a.Add("2015 /Q5");
          a.Add("2015 /Q6");
          a.Add("2015 /Q7");
          a.Add("2015 /Q8");
    
          a.Sort(new StringComparer());
    
          foreach (var x in a)
          {
            Console.WriteLine(x);
          }
    
          Console.WriteLine("END");
          Console.ReadLine();
    
        }
      }
