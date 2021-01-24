    var vm = new ViewModel();
    vm.List.Add(new ExpanderData() { SomeText = "Text1" });
    vm.List.Add(new ExpanderData() { SomeText = "Text2" });
    vm.List.Add(new ExpanderData() { SomeText = "Text3" });
    vm.List.Add(new ExpanderData() { SomeText = "Text4" });
    
    this.DataContext = vm;
