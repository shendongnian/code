    private void GetWorkItem(object sender, EventArgs e)
            {
                System.Threading.Tasks.Task.Factory.StartNew(() =>
                 {  
                     var w = GetItems(123);
                     MessageBox.Show(w.Url);
                 });
    
            }
    
     public WorkItem GetItems(int itemId)
            {
                var myCredentials = new VssClientCredentials();
                var vstsConnection = new VssConnection(new Uri(@"https://xxx.visualstudio.com/"), myCredentials);
                var vstsClient = vstsConnection.GetClient<WorkItemTrackingHttpClient>();
                var workItem =  vstsClient.GetWorkItemAsync(itemId).Result;
    
                return workItem;
            }
