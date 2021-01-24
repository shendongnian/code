    for (int i = 1; i < table.Rows.Count; i++)
    {
        DataRow dr = table.Rows[i];
        string input = Convert.ToString(dr[0]);
        var reg = new Regex(pattern2, RegexOptions.IgnoreCase);
        Match match = reg.Match(input);
        string input2 = Convert.ToString(dr[1]);
        var reg2 = new Regex(pattern, RegexOptions.IgnoreCase);
        Match match2 = reg2.Match(input2);
        if (match.Success && match2.Success)
        {
            Person addtable = new Person()
            {
                ncode = Convert.ToString(dr[0]),
                nname = Convert.ToString(dr[1])
            };
            if (ValidateNewPerson(addtable, db))
                db.People.Add(addtable);
        }
    }
