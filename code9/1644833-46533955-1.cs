    foreach (var line in lines)
    {
      if (line != string.Empty)
      {
          var newLine = line.Remove(0, 8);
    
          if (line.Contains("package:/system/app"))
          {
              lvItem.Text = newLine;
          }
          if (line.Contains("package:/system/priv-app"))
          {
              lvItem.SubItems.Add(newLine);
          }
          if (line.Contains("package:/data/app"))
          {
              lvItem.SubItems.Add(newLine);
          }
       }            
    }
    
    ApkList.Items.Add(lvItem);
