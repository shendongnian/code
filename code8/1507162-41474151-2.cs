    private static void ProcessEnded(object sender, EventArrivedEventArgs e)
    {
        Console.WriteLine($"Process ended event at: {DateTime.Now}");
        var targetProcess = e.NewEvent.Properties["TargetInstance"].Value as ManagementBaseObject;
        if (targetProcess != null)
        {
            Console.WriteLine("Properties:");
            foreach (PropertyData data in targetProcess.Properties)
            {
                Console.WriteLine($"{data.Name} = {data.Value}");
            }
            DateTime creationDate = GetDateTimeOrDefault(targetProcess.Properties["CreationDate"], DateTime.Now);
            DateTime terminationDate = GetDateTimeOrDefault(targetProcess.Properties["TerminationDate"], DateTime.Now);
            var totalRunTime = (terminationDate - creationDate).TotalSeconds;
            Console.WriteLine($"Creation: {creationDate}, Termination: {terminationDate}, Elapsed: {totalRunTime}");
            // this.logger.addRuntimeData(totalRunTime);
        }
        else
        {
            Console.WriteLine("Could not get target process");
        }
    }
    private static DateTime GetDateTimeOrDefault(PropertyData managementDateProperty, DateTime defaultValue)
    {
        string dateString = managementDateProperty.Value as string;
        if (!string.IsNullOrEmpty(dateString))
        {
            return ManagementDateTimeConverter.ToDateTime(dateString);
        }
        else
        {
            return defaultValue;
        }
    }
