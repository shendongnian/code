    VM DBvm = ctx.VirtualMachines.Find(vm.VM_Hostname);
    if (DBvm==null)
    {
        ctx.VirtualMachines.Add(vm);
    
    }
    // else VM exists so, update it [ERROR OCCURS HERE]
    else
    {
    
        //DBvm = vm;
        //ctx.Entry(vm).State = EntityState.Modified;   I tried various update methods too
        foreach (var disk in vm.disks)
        {
            ctx.Disks.Attach(disk);
            ctx.Entry(disk).State = EntityState.Modified;
        }
        foreach (var process in vm.Processes)
        {
            ctx.Processes.Attach(process);
            ctx.Entry(process).State = EntityState.Modified;
        }
        DBvm.disks = vm.disks;
        DBvm.Processes = vm.Processes;
        DBvm.VMstatus = vm.VMstatus;
    
    }
