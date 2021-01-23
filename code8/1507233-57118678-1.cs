    var session = ClrMD.Extensions.ClrMDSession.LoadCrashDump(@"dmpfile.dmp");
    var stateMachineTypes = (
        from type in session.Heap.EnumerateTypes()
        where type.Interfaces.Any(item => item.Name == "System.Runtime.CompilerServices.IAsyncStateMachine")
        select type);
    session.Heap.EnumerateDynamicObjects(stateMachineTypes).Dump(2);
