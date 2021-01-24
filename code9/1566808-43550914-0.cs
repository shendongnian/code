    IL_0033:  ldloc.0     // list
    IL_0034:  ldsfld      UserQuery+<>c.<>9__0_0
    IL_0039:  dup         
    IL_003A:  brtrue.s    IL_0053
    IL_003C:  pop         
    IL_003D:  ldsfld      UserQuery+<>c.<>9
    IL_0042:  ldftn       UserQuery+<>c.<Main>b__0_0
    IL_0048:  newobj      System.Func<UserQuery+Test,System.Boolean>..ctor
    IL_004D:  dup         
    IL_004E:  stsfld      UserQuery+<>c.<>9__0_0
    IL_0053:  call        System.Linq.Enumerable.Where<Test>
    IL_0058:  stloc.3     // filteredList
    IL_0059:  nop         
    IL_005A:  ldloc.3     // filteredList
    IL_005B:  callvirt    System.Collections.Generic.IEnumerable<UserQuery+Test>.GetEnumerator
    IL_0060:  stloc.s     04 
    IL_0062:  br.s        IL_0077
    IL_0064:  ldloc.s     04 
    IL_0066:  callvirt    System.Collections.Generic.IEnumerator<UserQuery+Test>.get_Current
    IL_006B:  stloc.s     05 // item
    IL_006D:  nop         
    IL_006E:  ldloc.s     05 // item
    IL_0070:  call        LINQPad.Extensions.Dump<Test>
    IL_0075:  pop         
    IL_0076:  nop         
    IL_0077:  ldloc.s     04 
    IL_0079:  callvirt    System.Collections.IEnumerator.MoveNext
    IL_007E:  brtrue.s    IL_0064
    IL_0080:  leave.s     IL_008F
    IL_0082:  ldloc.s     04 
    IL_0084:  brfalse.s   IL_008E
    IL_0086:  ldloc.s     04 
    IL_0088:  callvirt    System.IDisposable.Dispose
    IL_008D:  nop         
    IL_008E:  endfinally  
    IL_008F:  nop         
    IL_0090:  ldloc.0     // list
    IL_0091:  ldsfld      UserQuery+<>c.<>9__0_1
    IL_0096:  dup         
    IL_0097:  brtrue.s    IL_00B0
    IL_0099:  pop         
    IL_009A:  ldsfld      UserQuery+<>c.<>9
    IL_009F:  ldftn       UserQuery+<>c.<Main>b__0_1
    IL_00A5:  newobj      System.Func<UserQuery+Test,System.Boolean>..ctor
    IL_00AA:  dup         
    IL_00AB:  stsfld      UserQuery+<>c.<>9__0_1
    IL_00B0:  call        System.Linq.Enumerable.Where<Test>
    IL_00B5:  callvirt    System.Collections.Generic.IEnumerable<UserQuery+Test>.GetEnumerator
    IL_00BA:  stloc.s     06 
    IL_00BC:  br.s        IL_00D1
    IL_00BE:  ldloc.s     06 
    IL_00C0:  callvirt    System.Collections.Generic.IEnumerator<UserQuery+Test>.get_Current
    IL_00C5:  stloc.s     07 // item
    IL_00C7:  nop         
    IL_00C8:  ldloc.s     07 // item
    IL_00CA:  call        LINQPad.Extensions.Dump<Test>
    void Main()
    {
    	List<Test> list = new List<Test>();
    	var x1 = new Test() { IsNull = false };
    	var x2 = new Test() { IsNull = true };
    	list.Add(x1);
    	list.Add(x2);
    	// Approach1
    	var filteredList = list.Where(x => x.IsNull == true);
    	foreach (var item in filteredList)
    	{
    		item.Dump();
    	}
    	// Approach2
    	foreach (var item in list.Where(x => x.IsNull == true))
    	{
    		item.Dump();
    	}
    }
