    void LoadItems()
    {
      var vms = Directory.GetDirectories(somePath)
          .AsParallel().Select(dir =>
               new ItemViewModel(new ItemSerializer().Deserialize(dir)))
          .ToList();
      foreach (var vm in vms)
      {
        DoSomething(vm);
      }
    }
