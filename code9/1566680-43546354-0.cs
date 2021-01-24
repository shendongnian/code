    static void Theme(List<Class> list) {
         var dict = new Dictionary<string, int>();
         for (var current in list) {
              if (dict.ContainsKey(current.Theme) {
                  dict[current.Theme]++;
              } else {
                  dict[current.Theme] = 1;
              }
         }
    }
