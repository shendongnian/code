     List<IModule> _modules;
     public ReadOnlyCollection<IModule> Modules 
     {
         get
         {
             return Modules;
         }
         private set
         {
             Modules = value;
         }
     }
