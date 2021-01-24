       <StackLayout>
            <Label Text="Welcome to Xamarin Forms!" IsVisible="{Binding ShowLabel}">
            </Label>
            <ListView x:Name="TheListView" />
            
            <Button x:Name="btnAddItem" Text="Add an item" Clicked="btnAddItem_Clicked"   />
        </StackLayout>
   
     public partial class MainPage : ContentPage, INotifyPropertyChanged
        {
	public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<string> _items = new ObservableCollection<string>();
        public bool ShowLabel
        {
            get
            {
                return !(Items.Count > 0);
            }
        }
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                
            }
        }
        public MainPage()
		{
			InitializeComponent();          
            TheListView.ItemsSource = _items;
            BindingContext = this;
        }
        private void btnAddItem_Clicked(object sender, EventArgs e)
        {
            Items.Add("Add a item");
            NotifyPropertyChanged("ShowLabel");            
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }}
