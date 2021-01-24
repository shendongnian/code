    IL_0000:  call        UserQuery+g.GetList
    IL_0005:  callvirt    System.Collections.Generic.IEnumerable<System.Object>.GetEnumerator
    IL_000A:  stloc.0     
    IL_000B:  br.s        IL_0014
    IL_000D:  ldloc.0     
    IL_000E:  callvirt    System.Collections.Generic.IEnumerator<System.Object>.get_Current
    IL_0013:  pop         
    IL_0014:  ldloc.0     
    IL_0015:  callvirt    System.Collections.IEnumerator.MoveNext
    IL_001A:  brtrue.s    IL_000D
    IL_001C:  leave.s     IL_0028
    IL_001E:  ldloc.0     
    IL_001F:  brfalse.s   IL_0027
    IL_0021:  ldloc.0     
    IL_0022:  callvirt    System.IDisposable.Dispose
    IL_0027:  endfinally  
    IL_0028:  ret
