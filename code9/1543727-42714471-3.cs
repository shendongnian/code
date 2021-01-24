    int h = 0;
    int g = 0;
    var rows = File.ReadAllLines(@"C:2.txt");
    double[][] datafile1 = new double[lines.Length][];
    foreach (var row in rows)
    {
        h = 0;
    
        // passing a list of separators, you catch both of your cases.
        columns = row.Trim().Split(new[] { ',', ' '}));
    
        // You read dynamically the number of columns, instead of having to set 
        // the correct number
        datafile1[g] = new double[columns.Length];
    
        foreach (var column in columns)
        {
            datafile1[g][h] = double.Parse(column);
            h++;
        }
        g++;
    }
