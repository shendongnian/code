        string[] oldname = new string[] { "arun", "jack", "tom" };
        string[] newname = new string[] { "jack", "hardy", "arun" };
        
        List<string> distinctoldname = new List<string>();
        List<string> distinctnewname = new List<string>();
        
        foreach (string txt in oldname)
        {
           if (Array.IndexOf(newname, txt) == -1)
             distinctoldname.Add(txt);
         }
        
         foreach (string txt in newname)
         {
            if (Array.IndexOf(oldname, txt) == -1)
              distinctnewname.Add(txt);
         }
        
        
       //here you can get both the arrays separately
