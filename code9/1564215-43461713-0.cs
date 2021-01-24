    StringBuilder selection = new StringBuilder();
    if (CarNotes != null && CarNotes.Length > 0)
    {
       foreach (string s in CarNotes)
       {
          selection.Append(s);
          selection.Append(", ");
       }
    }
    //Trim the ending space, then trim the ending comma
    return selection.ToString().TrimEnd().TrimEnd(',');
