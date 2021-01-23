    public void MyMethod<T>(List<I_SP> items) where T:I_SP {
      foreach (var x in items.OfType<T>)
      {
        WPSitems ding = new WPSitems();
        ding.ID = x.ID;
        ding.Naam = x.Naam;
        ......
      }
    }
