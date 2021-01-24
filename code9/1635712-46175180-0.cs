    int emptyindex = -1;
    foreach(string s in rygga)
    {
      if(s == "")
      {
        emptyIndex = Array.IndexOf(rygga,s);
        break;
      }
    }
    if(emptyindex >= 0)
    {
      rygga[emptyindex] = //UserInput;
    }
    else
    {
     //Inform that there is no more space to fill
     //Eventually you can overwrite index 0 then. Depends on what suits you better
    }
