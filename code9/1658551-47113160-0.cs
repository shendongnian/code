    public class MyViewModel : ViewModelBase
	{
	    private bool _isEnabled = false;
		public bool IsEnabled 
		{
			get => _isEnabled;
			set => Set( ref _isEnabled, value);
		}
	}
	<StackLayout HorizontalOptions="CenterAndExpand" IsEnabled="{Binding IsEnabled}" x:Name="More" >
		...
	</StackLayout>
	private void ChallengeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItem is MyViewModel viewModel)
		{
			viewModel.IsEnabled = true;
		}
	}
