    foreach (string s in lines)
    {
        //int nmbr = 0;
        var numbers = s.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
        foreach(var number in numbers)
        {
            var convertedNumber = Convert.ToDouble(number);
            list.Add(convertedNumber);
            listfile.Items.Add(convertedNumber);
        }
     }
