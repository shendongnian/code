    string triggerName = "When_a_new_email_arrives";
    string resourceGroupName = "my resourcegroup name";
    string workflowName = "my-LogicApp";
    string subscriptionID = "my-subscriptionID";
    var workflow = await _client.Workflows.GetAsync(resourceGroupName, workflowName);
    
    string url = string.Format("https://management.azure.com/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Logic/workflows/{2}?api-version=2016-06-01",
        subscriptionID, resourceGroupName, workflowName);
    HttpClient client = new HttpClient();
    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Put, url);
    message.Headers.Add("Authorization", "Bearer put your token here");
    message.Headers.Add("Accept", "application/json");
    message.Headers.Add("Expect", "100-continue");
    
    dynamic workflowDefinition = workflow.Definition;
    workflowDefinition.triggers[triggerName]["recurrence"] = JToken.FromObject(new { frequency = "Minute", interval = 20 });
    
    string s = workflow.ToString();
    string workflowString = JsonConvert.SerializeObject(workflow, _client.SerializationSettings);
    
    message.Content = new StringContent(workflowString, Encoding.UTF8, "application/json");
    await client.SendAsync(message);
