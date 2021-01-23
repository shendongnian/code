    <Grid>
        <StackPanel Orientation="Horizontal">
            <ListBox x:Name="Emp" ItemsSource="{Binding EmpCollection}" SelectionMode="Extended">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <ToggleButton IsChecked="{Binding IsSelected, Mode=TwoWay, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListBoxItem}}}">
                                <!--StackPanel will have more items-->
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="{Binding Title}"/>
                                </StackPanel>
                            </ToggleButton>
                        </StackPanel>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
            <ListBox x:Name="SelectedEmp" ItemsSource="{Binding ElementName=Emp,Path=SelectedItems}" DisplayMemberPath="Title"/>
        </StackPanel>
    </Grid>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    }
    class ViewModel
    {
        public ObservableCollection<Emp> EmpCollection { get; set; }
        public ViewModel()
        {
            EmpCollection = new ObservableCollection<Emp>();
            for (int i = 0; i < 10; i++)
            {
                EmpCollection.Add(new Emp() {Title = "Title"+i});
            }
        }
        
    }
    class Emp:INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
