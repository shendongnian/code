    public sealed partial class WebViewLocalImage : Page
    {
    	public WebViewLocalImage()
    	{
    		this.InitializeComponent();
    		Loaded += MainPage_Loaded;
    	}
    
    	private void MainPage_Loaded(object sender, RoutedEventArgs e)
    	{
    		var uri = this.myWebView.BuildLocalStreamUri("InternalAssets", "example.html");
    		this.myWebView.NavigateToLocalStreamUri(uri, new StreamUriResolver());
    	}
    }
    
    public sealed class StreamUriResolver : IUriToStreamResolver
    {
    	public IAsyncOperation<IInputStream> UriToStreamAsync(Uri uri)
    	{
    		string path = uri.AbsolutePath;
    		return GetContent(path).AsAsyncOperation();
    	}
    
    	private async Task<IInputStream> GetContent(string URIPath)
    	{
    		try
    		{
    			Uri localUri = new Uri("ms-appx:///Assets/" + URIPath);
    			StorageFile f = await StorageFile.GetFileFromApplicationUriAsync(localUri);
    			IRandomAccessStream stream = await f.OpenAsync(FileAccessMode.Read);
    			return stream.GetInputStreamAt(0);
    		}
    		catch (Exception)
    		{
    			System.Diagnostics.Debug.WriteLine("Invalid URI");
    		}
    		return null;
    	}
    }
