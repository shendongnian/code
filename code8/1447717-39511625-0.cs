    static MyApp(){
      AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(MainResolver);
    }
    static void main(string[] args){
      //remove MainResolver
      AppDomain.CurrentDomain.AssemblyResolve -= MainResolver;
      MyClass my = new MyClass();
      my.DoWork();
    }
