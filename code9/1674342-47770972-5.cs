    .class public auto ansi beforefieldinit Abstract_Test_Abstract.NotAbstract
           extends [mscorlib]System.Object
    {
      .method public hidebysig instance void 
              PrintOut() cil managed
      {
    //000012:         {
        IL_0000:  nop
    //000013:             Console.WriteLine(nameof(NotAbstract));
        IL_0001:  ldstr      "NotAbstract"
        IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
        IL_000b:  nop
    //000014:         }
        IL_000c:  ret
      } // end of method NotAbstract::PrintOut
    
      .method public hidebysig specialname rtspecialname 
              instance void  .ctor() cil managed
      {
      } // end of method NotAbstract::.ctor
    
    } // end of class Abstract_Test_Abstract.NotAbstract
    
    .class private auto ansi beforefieldinit Abstract_Test_Abstract.Program
           extends Abstract_Test_Abstract.NotAbstract
    {
      .method private hidebysig static void  Main(string[] args) cil managed
      {
        .entrypoint
        .maxstack  1
        .locals init ([0] class Abstract_Test_Abstract.Program p)
    //000012:         {
        IL_0000:  nop
    //000013:             var p = new Program();
        IL_0001:  newobj     instance void Abstract_Test_Abstract.Program::.ctor()
        IL_0006:  stloc.0
    //000014:             p.PrintOut();
        IL_0007:  ldloc.0
        IL_0008:  callvirt   instance void Abstract_Test_Abstract.NotAbstract::PrintOut()
        IL_000d:  nop
    //000015:         }
        IL_000e:  ret
      } // end of method Program::Main
    
      .method public hidebysig specialname rtspecialname 
              instance void  .ctor() cil managed
      {
      } // end of method Program::.ctor
    
    } // end of class Abstract_Test_Abstract.Program
