    using System;
    public class Task : TableEntity
    {
        public string Name { get; set; }
    }
    public static async Task Run(TimerInfo myTimer, IQueryable<Task> inputTable, TraceWriter log)
    {
        foreach (var task in inputTable) {
	    	log.Info($"Processing task '{task.Name}' at: {DateTime.Now}");
        }
        log.Info($"Timer trigger executed at: {DateTime.Now}");
    }
