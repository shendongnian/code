    .method public hidebysig static class SingletonSpeedTest.Singleton2 
        Instance() cil managed
    {
      // Code size       37 (0x25)
      .maxstack  2
      .locals init ([0] bool V_0,
           [1] class SingletonSpeedTest.Singleton2 V_1)
      IL_0000:  nop
      IL_0001:  ldsfld     class SingletonSpeedTest.Singleton2 SingletonSpeedTest.Singleton2::'instance'
      IL_0006:  ldnull
      IL_0007:  cgt.un
      IL_0009:  stloc.0
      IL_000a:  ldloc.0
      IL_000b:  brfalse.s  IL_0015
      IL_000d:  ldsfld     class SingletonSpeedTest.Singleton2 SingletonSpeedTest.Singleton2::'instance'
      IL_0012:  stloc.1
      IL_0013:  br.s       IL_0023
      IL_0015:  newobj     instance void SingletonSpeedTest.Singleton2::.ctor()
      IL_001a:  dup
      IL_001b:  stsfld     class SingletonSpeedTest.Singleton2 SingletonSpeedTest.Singleton2::'instance'
      IL_0020:  stloc.1
      IL_0021:  br.s       IL_0023
      IL_0023:  ldloc.1
      IL_0024:  ret
    } // end of method Singleton2::Instance
