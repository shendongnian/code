    public DetachForm(MessageViewModel messageViewModel)  //  <--- first object in memory
    {            
        a = new MessageViewModel();  //  <--- create a new object in memory
        a = messageViewModel;  // <--- change the reference a to reference the messageViewModel
        var b = new MessageViewModel();  //  <--- create a new third object in memory
        b = a;  //  <--- change b to reference the same object as a
    
        a.id=1;  // At this point messageViewModel, a, b - all reference the same object in memory
    }
