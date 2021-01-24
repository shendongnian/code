      using System.Linq;
      ... 
      // Or List<string> 
      string[] items = new string[] {
        "Hi.",
        "its me."
      };
      string result = string.Join(" ", items
        .Select((item, index) => $"{index + 1}){item}"));
