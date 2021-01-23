    Regex reg = new Regex(@"[A-Za-z]+ [A-Za-z]+");
    string Delname = bkDel.ContactName;
        Delname = Delname.Trim()
        if (!reg.IsMatch(Delname)){
        // Don't split
        return;
    }
    string[] Deltmp = Delname.Split(' ');
    string DelFirstName = Deltmp[0];
    string DelLastName = Deltmp[1];
