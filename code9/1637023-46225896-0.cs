     var options = select.Options();
     if (options.Any(o => o.Text.Contains(itemText)) 
     {
      select.SelectByIndex(options.IndexOf(options.First(o => o.Text.Contains(itemText))));
     }
    }
