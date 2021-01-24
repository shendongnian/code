    foreach (var selTPL in mkTPL.Selections)
    {   
        foreach (var selDB in mkDB.Selections)
        {
            if (selTPL.IsTheSame(selDB))
            {
                selTPL.OddOrResultValue = selDB.OddOrResultValue;
                break; // <--
            }
        }
    }
