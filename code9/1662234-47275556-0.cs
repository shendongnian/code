    public void InsertTask(Core.Domain.Tasks.ScheduleTask task)
        {
            task.Enabled = true;
            task.Name = "Amazon Inventory Update Sync";
            task.Type = "Nop.Plugin.Feed.Froogle.Tasks.CreateAmazonInventoryUpdateTask, Nop.Plugin.Feed.Froogle";
            task.Seconds = 60;
            task.StopOnError = false;
        }
