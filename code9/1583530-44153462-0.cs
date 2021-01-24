        Dictionary<bool, int> X = new Dictionary<bool, int>() {
          {true, 5},
          {false, -15},
        };
        Dictionary<bool, int> OtherX = new Dictionary<bool, int>() {
          {true, 123},
          {false, 456},
        };
 
        ...
        private static int GetIntFromDictionary(Dictionary<bool, int> dict, bool val) {
          return dict[val];
        }    
        ...
        int result1 = GetIntFromDictionary(X, true);
        int result2 = GetIntFromDictionary(X, false);
        int result3 = GetIntFromDictionary(OtherX, true);
        int result4 = GetIntFromDictionary(OtherX, false);
     
