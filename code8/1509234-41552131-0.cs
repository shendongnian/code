        AzureMachineLearningTextAnalytics textAnalyzer = new AzureMachineLearningTextAnalytics();
    var topicResult = textAnalyzer.DetectTopicsWithOperationResponseAsync(textAnalyticsAccountKey, null, null, null, topicDetection);
    string operationId = topicResult.Result.Response.Headers.Location.Segments[topicResult.Result.Response.Headers.Location.Segments.Length - 1];
    var status = textAnalyzer.OperationStatus(operationId, textAnalyticsAccountKey);
    
    while ((((MySample.TextAnalytics.Models.OperationResult)status).Status == "NotStarted") ||
           (((MySample.TextAnalytics.Models.OperationResult)status).Status == "Running"))
    {
        System.Threading.Thread.Sleep(20000);
        status = textAnalyzer.OperationStatus(operationId, textAnalyticsAccountKey);
    }
    
    if (((Terawe.Retail.TextAnalytics.Models.OperationResult)status).Status == "Failed")
    {
        // Log an error to the console
        Console.WriteLine($"Topic detection failed with status: {((MySample.TextAnalytics.Models.OperationResult)status).Message}");
    }
    else
    {
        // Process the phrases
    }
