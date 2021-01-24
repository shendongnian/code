    using System;
    public class MyInput : TableEntity
    {
        public string Name { get; set; }
    }
    public static async Task Run(TimerInfo myTimer, IQueryable<MyInput> inputTable, TraceWriter log)
    {
        foreach (var item in inputTable) {
	    	log.Info($"Processing item '{item.Name}' at: {DateTime.Now}");
        }
        log.Info($"Timer trigger executed at: {DateTime.Now}");
    }
