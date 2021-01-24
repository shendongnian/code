    var data = "'EEENKDDDDKKKNNKDK' ";
    char curr_c = '\x0';           // avoid unasssinged warning 
    int count = 0;                 // counter for the curr_c occurences in row
    string result = string.Empty;  // resulting string
    foreach (var c in data)        // process every character of data in order     
    {
        if (c != curr_c)           // new character found
        {
            if (count > 1)         // more then 1, add count as string and the char
                result += Convert.ToString(count) + curr_c;
            else if (count > 0)    // avoid initial `\x0` being put into string
                 result += curr_c;
            curr_c = c;            // remember new character
            count = 1;             // so far we found this one 
        }
        else
            count++;               // not new, increment counter
    }
    // add the last counted char as well
    if (count > 1)
        result += Convert.ToString(count) + curr_c;
    else
        result += curr_c;
    // output
    Console.WriteLine(data + " ==> " + result);
