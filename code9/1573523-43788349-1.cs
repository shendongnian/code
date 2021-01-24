    public list<MyClass> GettAll(string id)
    {
      var item = sQLiteConnection.Table<MyClass>().Where(e =>  (e.Id == id) && (e.name == Currentname));
    
      return item.ToList();
    }
