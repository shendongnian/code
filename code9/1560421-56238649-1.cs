     // Composition Root in the top level module
     // Both assemblies
     //    * A     that contains IServiceA
     //    * AImpl that contains an implementation, ServiceAImpl
     // are referenced here 
     public void CompositionRoot()
     {
          ServiceAFactory.SetProvider( () =>
             {
                 return new ServiceAImpl();
             } );
     }
