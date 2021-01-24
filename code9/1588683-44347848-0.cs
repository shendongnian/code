     using System.Globalization;
     using System.Linq;
     using System.Text.RegularExpressions;
     ... 
     string transform = "matrix(0.40438612,-0.91458836,0.92071162,0.39024365,0,0)";
     double[] result = Regex
       .Matches(transform, @"-?[0-9]*\.?[0-9]+")
       .OfType<Match>()
       .Take(2)
       .Select(match => double.Parse(match.Value, CultureInfo.InvariantCulture))
       .ToArray(); 
