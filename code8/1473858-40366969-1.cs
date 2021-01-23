     // imagine we don't know the actual size 
     string[] updatedSg = new string[0];
     // add sg.Length items to the array
     Array.Resize(ref updatedSg, sg.Length + updatedSg.Length);
     // copy the items
     for (int i = 0; i < sg.Length; ++i)
       updatedSg[updatedSg.Length - sg.Length + i - 1] = sg[i]; 
     // add updatedSg.Length items to the array
     Array.Resize(ref updatedSg, newSg.Length + updatedSg.Length);
     // copy the items 
     for (int i = 0; i < newSg.Length; ++i)
       updatedSg[updatedSg.Length - newSg.Length + i - 1] = newSg[i]; 
     
      
    
