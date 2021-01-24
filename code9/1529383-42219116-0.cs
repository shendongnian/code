        string[] oldname = new string[] { "arun", "jack", "tom" };
        string[] newname = new string[] { "jack", "hardy", "arun" };
        
        List<string> distinct = new List<string>();
        
        foreach (string txt in oldname)
        {
           if (Array.IndexOf(newname, txt) == -1)
             distinct.Add(txt);
         }
        
         foreach (string txt in newname)
         {
            if (Array.IndexOf(oldname, txt) == -1)
              distinct.Add(txt);
         }
        
        // Test 
        
        foreach (var item in distinct)
        {
           MessageBox.Show(item.ToString());
        }
