    var input = "1.0, 1.1, 2.0, 10.1, 10.2, 10.2.1";
    string result = string.Empty;
    var temp = input.Split(','); //You can also trim here as @Steve did
    foreach (var item in temp)
    {
       //cast it to double, then check if it's an integer
       if ((double.Parse(item.Trim())) % 1 == 0)
       {
           //this is an integer, the first digit will be changed, put "\n"
           result += "\n" + item;
       }
       else
       {
           //this is not an integer, continue as usual.
           result += item;
       }
    }
    
    //on this line the variable result is formatted the way you want.
    Console.WriteLine(result);
