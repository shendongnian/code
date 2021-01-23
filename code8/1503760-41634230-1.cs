	public partial class Signature
	{
		protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			await myCanvas.RestoreStrokesAsync(ApplicationData.Current.SharedLocalFolder, "strokes.gif");
			base.OnNavigatedTo(e);
		}
	
		protected override async void OnNavigatedFrom(NavigationEventArgs e)
		{
			await myCanvas.StoreStrokesAsync(ApplicationData.Current.SharedLocalFolder, "strokes.gif");
			base.OnNavigatedFrom(e);
		}
	}
