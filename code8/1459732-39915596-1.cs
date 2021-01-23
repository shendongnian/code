    internal class DialogService 
    {
    	public async Task<bool> ShowMvvmMessageBox(string question, string caption)
    	{
    		bool res = await Task<bool>.Factory.StartNew(() =>
    		{
    			MessageBoxResult result = MessageBox.Show(question, caption, MessageBoxButton.YesNo);
    			return result == MessageBoxResult.Yes;
    		});
    		return res;
    	}
    }
