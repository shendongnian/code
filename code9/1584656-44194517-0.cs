    // put dictionary A ~ T to a list of dictionary
    List<Dictionary<int, DictionarySetup>> dictionaries = new List<Dictionary<int, DictionarySetup>>{A,B,C, ... , T}; // Replace ... with D,E,F, etc. until T
    // iterate each dictionary and if found, exit the loop
    foreach(var dict in dictionaries)
    {
       if(Dictionary_Test(dict))
       {
          Dictionary_Find(Account_String, rowindex, dict, Cash_Value, txtCurrency.Text);
          break;
       }
    }
