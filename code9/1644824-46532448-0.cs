    <ListBox ItemsSource="{Binding Swversions}" x:Name="lstListBox">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding SW_Version}">
                        <TextBlock.InputBindings>
                            <MouseBinding MouseAction="LeftDoubleClick" 
                                          Command="{Binding ElementName=lstListBox,Path=DataContext.ListDoubleClickCommand}"
                                          CommandParameter="{Binding ElementName=lstListBox, Path=SelectedItem}"/>
                        </TextBlock.InputBindings>
                    </TextBlock>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
    class ViewModel
    {
        public List<swversion> Swversions { get; set; }
        public ICommand ListDoubleClickCommand { get; set; }
        public ViewModel()
        {
            Swversions = new List<swversion>()
            {
                new swversion() {SW_Version = "Version1"},
                new swversion() {SW_Version = "Version2"},
                new swversion() {SW_Version = "Version3"},
                new swversion() {SW_Version = "Version4"},
                new swversion() {SW_Version = "Version5"}
            };
            ListDoubleClickCommand = new RelayCommand(OnDoubleClick);
        }
        private void OnDoubleClick(object parameter)
        {
            
        }
    }
    class swversion
    {
        public string SW_Version { get; set; }
    }
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
