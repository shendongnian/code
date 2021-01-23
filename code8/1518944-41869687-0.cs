    StringBuilder number = new StringBuilder();
    List<string> test = new List<string>();
    foreach (char c in s)
        {
            if (Char.IsDigit(c)) {
               number.append(c);
            }
            else if (c == ' ' || c == ':') {
              //donnothing
            }
            else {
               if (number.Length > 0) {
               test.add(number.ToString());
               number.Clear();
               }
            }
        }
