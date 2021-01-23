    void GetAlphabetaValue(Items x)
    {
      x.Alphabet_value = new int[x.name.Length];
      for (int c = 0; c < x.Alphabet_value.Length; c++) 
      {
          string character = x.name.Substring (c, 1);
          character.ToLower ();
          switch (character) 
          {
          case "a":
             x.Alphabet_value [c] = 0;
             break;  
           ///Etc... //Etc..... And end.  
          }
       }
    }    
       
