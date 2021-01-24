    IL_0000:  ldarg.0     
    IL_0001:  call        UserQuery.GetSomeStuff
    IL_0006:  callvirt    System.Collections.Generic.List<System.String>.GetEnumerator
    IL_000B:  stloc.0     
    IL_000C:  br.s        IL_0016
    IL_000E:  ldloca.s    00 
    IL_0010:  call        System.Collections.Generic.List<System.String>.get_Current
    IL_0015:  pop         
    IL_0016:  ldloca.s    00 
    IL_0018:  call        System.Collections.Generic.List<System.String>.MoveNext
    IL_001D:  brtrue.s    IL_000E
    IL_001F:  leave.s     IL_002F
    IL_0021:  ldloca.s    00 
    IL_0023:  constrained. System.Collections.Generic.List<>.Enumerator
    IL_0029:  callvirt    System.IDisposable.Dispose
    IL_002E:  endfinally  
    IL_002F:  ret  
