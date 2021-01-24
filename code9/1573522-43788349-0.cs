        public list<MyClass> GettAll()
    {
      var item = sQLiteConnection.Table<MyClass>().Where(e =>  (e.Id ==  CurrentId) && (e.name == Currentname));
    
      return item.ToList();
    }
