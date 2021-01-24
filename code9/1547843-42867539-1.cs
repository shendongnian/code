    class Item
    {
        int a;
        int b;
        int c;
        string s;
        List<Day> days;
    }
    
    class SearchParams
    {
        int a;
        int b;
        int c;
        string s;
        Day d1;
        Day d2;
    }
    
    // Populate items
    var items = new List<Item>();
    items.Add(...);
    
    // Search items
    var par = new SearchParams { ... };
    var matches = items.Where(x=> 
        x.a == par.a &&
        x.b == par.b &&
        x.c == par.c &&
        x.s == par.s &&
        x.days.Any(d >= par.d1 && d <= par.d2)
    );
