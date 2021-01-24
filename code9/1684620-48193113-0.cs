    IL_01B2:  ldloc.1     // list
    IL_01B3:  ldloc.0     // CS$<>8__locals0
    IL_01B4:  ldftn       UserQuery+<>c__DisplayClass0_0.<Main>b__0
    IL_01BA:  newobj      System.Func<UserQuery+Dev,System.Boolean>..ctor
    IL_01BF:  call        System.Linq.Enumerable.Where<Dev>
    IL_01C4:  call        System.Linq.Enumerable.ToList<Dev>
    IL_01C9:  stloc.2     // q1
    IL_01CA:  ldloc.1     // list
    IL_01CB:  ldloc.0     // CS$<>8__locals0
    IL_01CC:  ldftn       UserQuery+<>c__DisplayClass0_0.<Main>b__2
    IL_01D2:  newobj      System.Func<UserQuery+Dev,System.Boolean>..ctor
    IL_01D7:  call        System.Linq.Enumerable.Where<Dev>
    IL_01DC:  call        System.Linq.Enumerable.ToList<Dev>
    IL_01E1:  stloc.3     // q2
