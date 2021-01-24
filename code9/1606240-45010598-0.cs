             <ListView ItemsSource="{Binding Elements}">
    			<ListView.ItemTemplate>
    				<DataTemplate>
    					<ViewCell>
    						<Grid>
    							<Grid.ColumnDefinitions>
    								<ColumnDefinition />
    								<ColumnDefinition />
    							</Grid.ColumnDefinitions>
    							<Entry Grid.Column="0" Text="{Binding Name,Mode=TwoWay}" />
    							<Label Grid.Column="1" Text="{Binding Name,Mode=TwoWay}" />
    						</Grid>
    					</ViewCell>
    				</DataTemplate>
    			</ListView.ItemTemplate>
    		</ListView>
        public partial class MainPage : ContentPage
    	{
    	    ObservableCollection<Model> elements; 
    		public ObservableCollection<Model> Elements
    		{
    		   get { return elements;}
    		   set { elements = value;}
    		}
    
    
    		public MainPage()
    		{
    			Elements = new ObservableCollection<Model>() { new Model() { Name = "One" }, new Model() { Name = "Two" } };
    			BindingContext = this;
    			InitializeComponent();
    		}
    	}
    
    	public class Model : INotifyPropertyChanged
    	{
    		string name;
    		public string Name
    		{
    		    get { return name; }
    		    set {
                  name = value;
    				NotifyPropertyChanged("Name");
                }
    		}
    
    		private void NotifyPropertyChanged(string propertyName)
    		{
    			if (PropertyChanged != null)
    			{
    				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    			}
    		}
        
    		public event PropertyChangedEventHandler PropertyChanged;
    	}
