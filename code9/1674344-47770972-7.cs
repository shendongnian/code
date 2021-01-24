    .class public abstract auto ansi beforefieldinit Abstract_Test_NotAbstract.IsAbstract
           extends [mscorlib]System.Object
    {
      .method public hidebysig newslot abstract virtual 
              instance void  PrintOut() cil managed
      {
      } // end of method IsAbstract::PrintOut
    
      .method family hidebysig specialname rtspecialname 
              instance void  .ctor() cil managed
      {
      } // end of method IsAbstract::.ctor
    
    } // end of class Abstract_Test_NotAbstract.IsAbstract
    
    .class private auto ansi beforefieldinit Abstract_Test_NotAbstract.Program
           extends Abstract_Test_NotAbstract.IsAbstract
    {
      .method private hidebysig static void  Main(string[] args) cil managed
      {
    //000012:         {
        IL_0000:  nop
    //000013:             var p = new Program();
        IL_0001:  newobj     instance void Abstract_Test_NotAbstract.Program::.ctor()
        IL_0006:  stloc.0
    //000014:             p.PrintOut();
        IL_0007:  ldloc.0
        IL_0008:  callvirt   instance void Abstract_Test_NotAbstract.IsAbstract::PrintOut()
        IL_000d:  nop
    //000015:         }
        IL_000e:  ret
      } // end of method Program::Main
    
      .method public hidebysig virtual instance void 
              PrintOut() cil managed
      {
        .maxstack  8
    //000016: 
    //000017:         public override void PrintOut()
    //000018:         {
        IL_0000:  nop
    //000019:             Console.WriteLine(nameof(IsAbstract));
        IL_0001:  ldstr      "IsAbstract"
        IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
        IL_000b:  nop
    //000020:         }
        IL_000c:  ret
      } // end of method Program::PrintOut
    
      .method public hidebysig specialname rtspecialname 
              instance void  .ctor() cil managed
      {
      } // end of method Program::.ctor
    
    } // end of class Abstract_Test_NotAbstract.Program
