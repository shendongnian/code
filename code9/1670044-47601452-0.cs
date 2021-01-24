    private IDictionary<Items, string> _itemStringMap = new Dicitionary<Items, string>()
    {
       { Items.item_1, String_1 },
       //Other items here
    };
    public void DoSomething(Items item)
    {
      var s = _itemStringMap[item];
      MethodNumberOne();
      MethodNumberTwo();
      MethodNumberThree();
      Console.WriteLine($"{0} is displayed on the page", s);
    }
