    public class RMssg
    {
    	public int ProgressIndicator { get; set; }
    	public User userInstance { get; set; }
    }
    
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
    	var progressIndicator = new Progress<RMssg>(r => ReportProgress(r));
    	await this.User.ReadUsers(progressIndicator, this.User);
    }
    
    void ReportProgress(RMssg rMssg)
    {
    	this.User.Val = rMssg.ProgressIndicator;
    	var user = rMssg.userInstance;
    }
    
    
    
    public async Task<bool> ReadUsers(IProgress<RMssg> pProgress, User pUser)
    {
    	for (int i = 1; i < 11; i++)
    	{
    		await Task.Delay(500);
    		var rMssg = new RMssg() { ProgressIndicator = i, userInstance = pUser };
    		pProgress.Report(rMssg);
    	}
    
    	return true;
    }
