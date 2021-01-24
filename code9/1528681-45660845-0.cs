    DownloadHandler downer = new DownloadHandler(this);
    browser.DownloadHandler = downer;
    downer.OnBeforeDownloadFired += OnBeforeDownloadFired;
    downer.OnDownloadUpdatedFired += OnDownloadUpdatedFired;
         		
    private void OnBeforeDownloadFired(object sender, DownloadItem e)
    {
        this.UpdateDownloadAction("OnBeforeDownload", e);
    }
		
    private void OnDownloadUpdatedFired(object sender, DownloadItem e)
	{
		this.UpdateDownloadAction("OnDownloadUpdated", e);
    }
    
    private void UpdateDownloadAction(string downloadAction, DownloadItem downloadItem)
    {
        /*
        this.Dispatcher.Invoke(() =>
        {
            var viewModel = (BrowserTabViewModel)this.DataContext;
            viewModel.LastDownloadAction = downloadAction;
            viewModel.DownloadItem = downloadItem;
        });
        */
    }
    
    // ...
    
    public class DownloadHandler : IDownloadHandler
    {
        public event EventHandler<DownloadItem> OnBeforeDownloadFired;
        
        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;
        
        MainForm mainForm;
	    
        public DownloadHandler(MainForm form)
        {
            mainForm = form;
        }
    
    // ...
    
