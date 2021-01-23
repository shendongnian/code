    string filter = "";
    int count = 0;
    foreach (name in names)
    {
        if (count != 0)
        {
            filter += " OR name = '" + name + "'";
        }
        else
        {
            filter += "name = '" + name + "'";
        }
        count += 1;
    }
