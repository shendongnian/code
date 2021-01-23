      Type result = part.RootElement
        .Descendants()
        .Select(e => e.GetType())
        .FirstOrDefault(e => trackedRevisionsElements.Contains(e));
    
      if (result != null) {   
        //TODO: Put the right message here
        MessageBox.Show(result.ToString());
        return true;
      }
      else 
        return false; 
