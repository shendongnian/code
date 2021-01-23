    string filterString = "";
    int count = 0;
    foreach (name in names)
    {
        if (count != 0)
        {
            filterString += " OR Responsible = '" + name + "'";
        }
        else
        {
            filterString += "Responsible = '" + name + "'";
        }
        count += 1;
    }
