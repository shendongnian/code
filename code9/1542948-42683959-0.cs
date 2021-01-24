    .method private hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
      // Code size       14 (0xe)
      .maxstack  1
      .locals init ([0] class ConsoleApplication2.C x1,
               [1] class ConsoleApplication2.C x2)
      IL_0000:  nop
      IL_0001:  newobj     instance void ConsoleApplication2.C::.ctor()
      IL_0006:  stloc.0
      IL_0007:  newobj     instance void ConsoleApplication2.C::.ctor()
      IL_000c:  stloc.1
      IL_000d:  ret
    } // end of method Program::Main
