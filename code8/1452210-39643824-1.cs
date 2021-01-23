    try
    {
         IDictionary<int, string> dict = new Dictionary<int, string>();
    
         dict.Add(0, "a");
         dict[0] = "b";  // update value to b for the first key
         dict[1] = "c";  // add new key value pair
         dict.Add(0, "d"); // throw Argument Exception
     }
     catch (Exception ex)
     {
         MessageBox.Show(ex.Message);
     }
