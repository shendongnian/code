    var toRemove = new List<xxCaseEntity>();
    foreach (xxCaseEntity ACTIONyy in actionsChecked)
    {
        if(ACTIONyy.XXStatusCode == 40 || ACTIONyy.XXStatusCode == 45)
        {
            toRemove.Add(ACTIONyy);
        }
    }
    foreach (var item in toRemove )
    {
        actionsChecked.Remove(item);
    }
