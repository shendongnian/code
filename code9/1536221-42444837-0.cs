    .method public hidebysig static class SingletonSpeedTest.Singleton1 
        Instance() cil managed
    {
      // Code size       33 (0x21)
      .maxstack  2
      .locals init ([0] bool V_0,
               [1] class SingletonSpeedTest.Singleton1 V_1)
      IL_0000:  nop
      IL_0001:  ldsfld     class SingletonSpeedTest.Singleton1 SingletonSpeedTest.Singleton1::'instance'
      IL_0006:  ldnull
      IL_0007:  ceq
      IL_0009:  stloc.0
      IL_000a:  ldloc.0
      IL_000b:  brfalse.s  IL_0017
      IL_000d:  newobj     instance void SingletonSpeedTest.Singleton1::.ctor()
      IL_0012:  stsfld     class SingletonSpeedTest.Singleton1 SingletonSpeedTest.Singleton1::'instance'
      IL_0017:  ldsfld     class SingletonSpeedTest.Singleton1 SingletonSpeedTest.Singleton1::'instance'
      IL_001c:  stloc.1
      IL_001d:  br.s       IL_001f
      IL_001f:  ldloc.1
      IL_0020:  ret
    } // end of method Singleton1::Instance
