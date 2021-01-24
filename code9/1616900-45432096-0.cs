    // you'll need to add `using System.Reflection;`
    List<Assembly> assembliesToInclude = new List<Assembly>();
    
    //Now, add in all the assemblies your app uses
    assembliesToInclude.Add(typeof(ClassInYourPCL).GetTypeInfo().Assembly);
    
    //Also do this for all your other 3rd party libraries
    
    Xamarin.Forms.Forms.Init(e, assembliesToInclude);
    // replaces Xamarin.Forms.Forms.Init(e);
