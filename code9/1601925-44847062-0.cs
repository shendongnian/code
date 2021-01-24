    public void Foo()
    {
      using (var db = new DataContext())
      {
        Bar a = this.GetBar();
        if (a != null)
        {
          db.Bars.Attach(a);
          a.Property1 = true;
          db.SubmitChanges();
        }
      }
    }
