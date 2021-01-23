    0:000> !dumpasync -stacks -roots
    Statistics:
                  MT    Count    TotalSize Class Name
    00007ffb564e9be0        1           96 System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[[System.Threading.Tasks.VoidTaskResult, System.Private.CoreLib],[StackOverflow41476418_Core.Program+<Hang>d__1, StackOverflow41476418_Core]]
    Total 1 objects
    In 1 chains.
             Address               MT     Size      State Description
    00000209915d21a8 00007ffb564e9be0       96          0 StackOverflow41476418_Core.Program+<Hang>d__1
    Async "stack":
    .00000209915d2738 System.Threading.Tasks.Task+SetOnInvokeMres
    GC roots:
        Thread bc20:
            000000e08057e8c0 00007ffbb580a292 System.Threading.Tasks.Task.SpinThenBlockingWait(Int32, System.Threading.CancellationToken) [/_/src/System.Private.CoreLib/shared/System/Threading/Tasks/Task.cs @ 2939]
                rbp+10: 000000e08057e930
                    ->  00000209915d21a8 System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[[System.Threading.Tasks.VoidTaskResult, System.Private.CoreLib],[StackOverflow41476418_Core.Program+<Hang>d__1, StackOverflow41476418_Core]]
        
            000000e08057e930 00007ffbb580a093 System.Threading.Tasks.Task.InternalWaitCore(Int32, System.Threading.CancellationToken) [/_/src/System.Private.CoreLib/shared/System/Threading/Tasks/Task.cs @ 2878]
                rsi: 
                    ->  00000209915d21a8 System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[[System.Threading.Tasks.VoidTaskResult, System.Private.CoreLib],[StackOverflow41476418_Core.Program+<Hang>d__1, StackOverflow41476418_Core]]
        
            000000e08057e9b0 00007ffbb5809f0a System.Threading.Tasks.Task.Wait(Int32, System.Threading.CancellationToken) [/_/src/System.Private.CoreLib/shared/System/Threading/Tasks/Task.cs @ 2789]
                rsi: 
                    ->  00000209915d21a8 System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[[System.Threading.Tasks.VoidTaskResult, System.Private.CoreLib],[StackOverflow41476418_Core.Program+<Hang>d__1, StackOverflow41476418_Core]]
        
    Windows symbol path parsing FAILED
            000000e08057ea10 00007ffb56421f17 StackOverflow41476418_Core.Program.Main(System.String[]) [C:\StackOverflow41476418_Core\Program.cs @ 12]
                rbp+28: 000000e08057ea38
                    ->  00000209915d21a8 System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[[System.Threading.Tasks.VoidTaskResult, System.Private.CoreLib],[StackOverflow41476418_Core.Program+<Hang>d__1, StackOverflow41476418_Core]]
        
            000000e08057ea10 00007ffb56421f17 StackOverflow41476418_Core.Program.Main(System.String[]) [C:\StackOverflow41476418_Core\Program.cs @ 12]
                rbp+30: 000000e08057ea40
                    ->  00000209915d21a8 System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1+AsyncStateMachineBox`1[[System.Threading.Tasks.VoidTaskResult, System.Private.CoreLib],[StackOverflow41476418_Core.Program+<Hang>d__1, StackOverflow41476418_Core]]
