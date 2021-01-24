    string test = "ABC0001";
    string leftSide = string.Join("", test.Take(3)); // take 3 of string 'ABC'
    int num = Convert.ToInt32(string.Join("", test.Skip(3))) + 1; // skip 3 to get 0001
    leftSide = leftSide + 
               string.Concat(Enumerable.Repeat("0", 4 - num.ToString().Length)) + 
               num; // ABC + repeat 0 elements according to increased num + append the new num
