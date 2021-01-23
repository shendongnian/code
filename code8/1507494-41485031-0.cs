    _schedualTaskService.InsertTask(new Nop.Core.Domain.Tasks.ScheduleTask()
    {
        Enabled = true,
        Name = "Product Sync",
        Seconds = 3600,
        StopOnError = false,
        Type = "Nop.Plugin.Misc.MereSync.ProductSyncTask, Nop.Plugin.Misc.MereSync"
    });
