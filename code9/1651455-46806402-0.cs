        List<string> keys = new List<string>();
        keys.Add("a");
        keys.Add("b");
        keys.Add("c");
        keys.Add("d");
        keys.Add("e");
        keys.Add("f");
        keys.Add("g");
       
     var fields = keys.Distinct().Select ((t,val)=> new { Key= t, Value= (val + 1)});
