        const String categoryName = "Processor";
        const String counterName = "% Processor Time";
        if ( !PerformanceCounterCategory.Exists(categoryName) ) 
        {
            CounterCreationDataCollection CCDC = new CounterCreationDataCollection();
            // Add the counter.
            CounterCreationData ETimeData = new CounterCreationData();
            ETimeData.CounterType = PerformanceCounterType.ElapsedTime;
            ETimeData.CounterName = counterName;
            CCDC.Add(ETimeData);	   
            // Create the category.
            PerformanceCounterCategory.Create(categoryName,
                    "Demonstrates ElapsedTime performance counter usage.",
                PerformanceCounterCategoryType.SingleInstance, CCDC);
        }
