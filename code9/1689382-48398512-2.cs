       <ListView
        		HasUnevenRows="True"
        		ItemsSource="{Binding ItemsSource}">
        		<ListView.ItemTemplate>
        			<DataTemplate>
        				<ViewCell>
        					<Label Text="{Binding Name}"/>
        				</ViewCell>
        			 </DataTemplate>
        		</ListView.ItemTemplate>
        </ListView>
     
       public partial class MainAssign : ContentPage
        	{
        		 
        		public MainAssign()
        		{
        			InitializeComponent();
        			BindingContext = new MainAssignViewModel();
        		}
        
        
        		protected override async void OnAppearing() {
        			base.OnAppearing();
        			await (BindingContext as MainAssignViewModel)?.LoadData();
        		}
        
        	}
        
        	public class MainAssignViewModel:INotifyPropertyChanged {
        
        		List<AssignListModel> _assignmentList;
        
        		public MainAssignViewModel() {
        			_dataService = new DataService();
        		}
        		public List<AssignListModel> AssignmentList {
        			get { return _assignmentList; }
        			set {
        				_assignmentList = value;
        				OnPropertyChanged(nameof(AssignmentList));
        			}
        		}
        
        		readonly DataService _dataService;
        
        		public async Task LoadData() {
        			AssignmentList = await _dataService.GetAssignmentItemsAsync();
        		}
        
        		public event PropertyChangedEventHandler PropertyChanged;
        
        		[NotifyPropertyChangedInvocator]
        		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        		}
        	}
 
