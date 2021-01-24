    var data = "'EEENKDDDDKKKNNKDK' ";
    char curr_c = '\x0';           // avoid unasssinged warning 
    int count = 0;                 // counter for the curr_c occurences in row
    string result = string.Empty;  // resulting string
    foreach (var c in data)        // process every character of data in order     
    {
        if (c != curr_c)           // new character found
        {
            if (count > 1)         
                result += Convert.ToString(count) + curr_c;
            else if (count > 0)
                result += curr_c;
            curr_c = c;
            count = 1;
        }
        else
            count++;
    }
    if (count > 1)
        result += Convert.ToString(count) + curr_c;
    else
        result += curr_c;
    Console.WriteLine(data + " ==> " + result);
