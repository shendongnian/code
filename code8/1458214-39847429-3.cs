    .method public final hidebysig virtual newslot specialname instance void 
      add_PropertyChanged(
        class [System]System.ComponentModel.PropertyChangedEventHandler 'value'
      ) cil managed 
    {
      .maxstack 8
    
      // [77 17 - 77 18]
      IL_0000: nop          
    
      // [77 19 - 77 20]
      IL_0001: ret          
    
    } // end of method Foo::add_PropertyChanged
    
    .method public final hidebysig virtual newslot specialname instance void 
      remove_PropertyChanged(
        class [System]System.ComponentModel.PropertyChangedEventHandler 'value'
      ) cil managed 
    {
      .maxstack 8
    
      // [78 20 - 78 21]
      IL_0000: nop          
    
      // [78 22 - 78 23]
      IL_0001: ret          
    
    } // end of method Foo::remove_PropertyChanged
    
    .event [System]System.ComponentModel.PropertyChangedEventHandler PropertyChanged
    {
      .addon instance void ConsoleApplication1.Foo::add_PropertyChanged(class [System]System.ComponentModel.PropertyChangedEventHandler) 
      .removeon instance void ConsoleApplication1.Foo::remove_PropertyChanged(class [System]System.ComponentModel.PropertyChangedEventHandler) 
    } // end of event Foo::PropertyChanged
