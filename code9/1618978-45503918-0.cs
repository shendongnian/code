    private readonly static object _mutex = new object();
    private List<MyClass> my = new List<MyClass>();
    public List<MyClass> My
    {
      get
      {
        lock (_mutex)
        {
          return my;
        }
      }
    }
    ...
    List<MyClass> my2 = await this.Exchange.GetDataAsync();
    lock (_mutex)
    {
      this.my = my2;
    }
