    var list = new List<string>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '10' };
    string test1s = "1";
    string test2s = "2";
    string test3s = "10";
    string test4s = "11";
    
    int test1i = null;
    int test2i = null;
    int test3i = null;
    int test4i = null;
    
    Int.TryParse(test1s, test1i);
    Int.TryParse(test2s, test2i);
    Int.TryParse(test3s, test3i);
    Int.TryParse(test4s, test4i);
    
    /* in case you do not want to unit test, 
    * you can obviously do something else with the variable here.
    * check on list size is to prevent index out of range exceptions and is optional */
    Assert.IsTrue(test1i.HasValue && list.Count() > test1i && list[test1i-1] == test1s));
    Assert.IsTrue(test2.HasValue && list.Count() > test2i && list[test2i-1] == test1s));
    Assert.IsTrue(test3.HasValue && list.Count() > test3i && list[test3i-1] == test1s));
    Assert.IsFalse(test4.HasValue && list.Count() > test4i && list[test4i-1] == test1s));
