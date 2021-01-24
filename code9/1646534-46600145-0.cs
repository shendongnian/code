    if (NameTB.Lines.Count() > 0) 
    {
        for (int i = 0; i < NameTB.Lines.Count(); i++)
        {
            nameList.Add(NameTB.Lines[i].Replace(Environment.NewLine, "").Trim());
        }
    }
