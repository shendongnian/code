    double lowest = Double.MaxValue;
    double highest = Double.MinValue;
    double average = 0;
    while ((line = file.ReadLine()) != null)
    {
        displayListBox.Items.Add(line);
        var dbl = Convert.ToDouble(line);
        if (dbl > highest)
            highest = dbl;
        if (dbl < lowest)
            lowest = dbl;
        dblAdd += dbl;
        counter++;
    }
    if (counter > 0)
    {
        average = dblAdd / (double)counter;
    }
    else
    {
        highest = lowest = 0;
    }
