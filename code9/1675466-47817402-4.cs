      using System.Linq;
      using System.Text.RegularExpressions;
      ...   
      string _UserDN = "CN=Adam Smith,OU=User,OU=CityName,DN=Domain,DC=Domain2";
      Dictionary<string, string[]> data = _Regex
       .Split(_UserDN, @"(?<!\\),") // We split on unescaped commas only
       .Select(item => item.Split(new char[] { '=' }, 2))
       .Where(pair => pair.Length >= 2)
       .GroupBy(pair => pair[0], 
                pair => pair[1]
                  .Replace(@"\,", ",")
                  .Replace(@"\\", @"\"), // drop escapements
                StringComparer.OrdinalIgnoreCase)
       .ToDictionary(chunk => chunk.Key,
                     chunk => chunk.ToArray());
