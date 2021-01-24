    using System.Collections;
    using System.Collections.Generic;
----------
    List<string> products = new List<string>() { "First", "Second", "Third", "Fourth" };
    IEnumerable item;
    var condition = false;
    if (condition)
    {
        item = products.Select(x=>x);
    }
    else
    {
        item = products.Where(x => x.StartsWith("F"));
    }
    var group =  item.Cast<string>().Where(/*...Here your conditions...*/)
