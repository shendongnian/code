      string source = "52+7+1";
      int sum = 0;                // initial sum is 0
      bool chaine_valide = true;  // the chain is valid (we don't have any counter examples)
      // Split on terms: 52, 7, 1
      foreach (string term in source.Split('+')) {
        int value;
        if (int.TryParse(term, out value))
          sum += value;          // valid term: add it up
        else {
          chaine_valide = false; // counter example: term is not a valid integer
          break;
        }
      }
      ...
      Console.Write(chaine_valide ? sum.ToString() : "Invalid formula");
        
