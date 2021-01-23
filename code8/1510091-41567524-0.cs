    int intList = File.ReadAllLines()
                      -- get only lines with numbers
                      .Where(l => {
                          int val;
                          bool isOk = int.TryParse(l, out value);
                          return isOk;
                      }
                      -- actual conversion
                      .Select(l => Convert.ToInt32(l)
                      .ToList();
