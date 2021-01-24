    var data = "'EEENKDDDDKKKNNKDK' ";
    char curr_c = '\x0'; // avoid unasssinged warning
    int count = 0;
    string result = string.Empty;
    foreach (var c in data)
    {
        if (c != curr_c)
        {
            if (count > 1)
                result += Convert.ToString(count) + curr_c;
            else
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
