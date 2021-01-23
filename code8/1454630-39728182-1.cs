    foreach (string line in File.ReadAllLines(@"Duomenys.txt"))
    {
        string[] a = line.split(',');
        int ISBN = Convert.ToInt32(a[0]);
        string BookName = a[1];
        string Author = a[2];
        string Genre = a[3];
        string Publisher = a[4];
        int PublishYear = Convert.ToInt32(a[5]);
        int PageNumber = Convert.ToInt32(a[6]);
    }
