    private void button_Click(object sender, RoutedEventArgs e)
            {
                var workitem = System.Threading.Tasks.Task.Run(() => GetItems(123)).Result;
    
            }
     public WorkItem GetItems(int itemId)
            {
                var myCredentials = new VssClientCredentials();
                var vstsConnection = new VssConnection(new Uri(@"https://XXX.visualstudio.com/"), myCredentials);
                var vstsClient = vstsConnection.GetClient<WorkItemTrackingHttpClient>();
                var workItem = vstsClient.GetWorkItemAsync(itemId).Result;
    
                return workItem;
            }
