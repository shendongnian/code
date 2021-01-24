    var newList = new List<MyViewModel>();
    foreach(var d in result)
    {
       var vm = new MyViewModel  { Id=d.Id, Name =d.Name};
       vm.SomeOtherProperty = d.SomeOtherProperty;
       vm.ExtraProperty = "New property on vm";
       newList.Add(vm);
    }
