    ProjectContext psContext = new ProjectContext(Strings.PWA_Url);
    var web = psContext.Web;
    var siteCollection = psContext.Site;
    var tasksList = web.Lists.GetByTitle("Project Server Workflow Tasks");
    var historyList = web.Lists.GetByTitle("Project Server Workflow History");
    
    psContext.Load(web, i => i.Id);
    psContext.Load(siteCollection, i => i.Id);
    psContext.Load(tasksList, i => i.Id);
    psContext.Load(historyList, i => i.Id);
    psContext.ExecuteQuery();
    
    WorkflowServicesManager wfServiceManager = new WorkflowServicesManager(psContext, web);
    WorkflowDefinition wfDefinition = new WorkflowDefinition(psContext);
    
    Guid subscriptionID = Guid.NewGuid();
    wfDefinition.DisplayName = "TestWorkflow";
    wfDefinition.Description = "TestWorkflow";
    wfDefinition.Xaml = Strings.Workflow_Simple;
    wfDefinition.SetProperty("isReusable", "false");
    wfDefinition.SetProperty("IsProjectMode", "true");
    //wfDefinition.SetProperty("AutosetStatusToStageName", "false");
    //wfDefinition.SetProperty("SPDConfig.LastEditMode", "TextBased");
    wfDefinition.SetProperty("RestrictToType", "Site");
    wfDefinition.SetProperty("TaskListId", tasksList.Id.ToString("B"));
    wfDefinition.SetProperty("HistoryListId", historyList.Id.ToString("B"));
    //wfDefinition.SetProperty("SPDConfig.StartManually", "true");
    //wfDefinition.SetProperty("SPDConfig.StartOnCreate", "false");
    //wfDefinition.SetProperty("SPDConfig.StartOnChange", "false");
    //wfDefinition.SetProperty("FormField", "&lt;Fields /&gt;");
    //wfDefinition.SetProperty("RequiresInitiationForm", "false");
    //wfDefinition.SetProperty("InitiationUrl", "");
    //wfDefinition.SetProperty("SubscriptionId", subscriptionID.ToString("B"));
    //wfDefinition.SetProperty("SubscriptionName", "TestWorkflow");
    WorkflowDeploymentService deployService = wfServiceManager.GetWorkflowDeploymentService();
    deployService.SaveDefinition(wfDefinition);
    
    psContext.Load(wfDefinition, i => i.Id);
    psContext.ExecuteQuery();
    
    deployService.PublishDefinition(wfDefinition.Id);
    psContext.ExecuteQuery();
    
    WorkflowSubscription subscription = new WorkflowSubscription(psContext);
    subscription.Id = subscriptionID;
    subscription.Name = "TestWorkflow";
    subscription.EventSourceId = new Guid("5122D555-E672-4E5D-A7C4-8084E694A257");
    subscription.EventTypes = new List<string>() { "WorkflowStart" };
    subscription.DefinitionId = wfDefinition.Id;
    //subscription.SetProperty("CreatedBySPD", "1");
    subscription.SetProperty("CurrentWebUri", Strings.PWA_Url_Https);
    subscription.SetProperty("HistoryListId", historyList.Id.ToString("B"));
    subscription.SetProperty("Microsoft.ProjectServer.ActivationProperties.CurrentStageId", "");
    //subscription.SetProperty("SharePointWorkflowContext.ActivationProperties.SiteId", siteCollection.Id.ToString("B"));
    subscription.SetProperty("TaskListId", tasksList.Id.ToString("B"));
    subscription.SetProperty("Microsoft.SharePoint.ActivationProperties.ParentContentTypeId", "");
    //subscription.SetProperty("SharePointWorkflowContext.ActivationProperties.WebId", web.Id.ToString("B"));
    subscription.SetProperty("Microsoft.ProjectServer.ActivationProperties.ProjectId", "");
    subscription.SetProperty("Microsoft.ProjectServer.ActivationProperties.RequestedStageId", "");
    
    WorkflowSubscriptionService subscriptionService = wfServiceManager.GetWorkflowSubscriptionService();
    subscriptionService.PublishSubscription(subscription);
    psContext.ExecuteQuery();
