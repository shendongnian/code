    public class SearchTextBox : TextBox
    {
        public static readonly DependencyProperty SearchCommandProperty = DependencyProperty.Register(
            "SearchCommand", typeof(ICommand), typeof(SearchTextBox), new PropertyMetadata(default(ICommand)));
        public SearchTextBox()
        {
            DeleteSearchCommand = new Command
            {
                ExecuteHandler = o => Clear()
            };
        }
        public ICommand SearchCommand
        {
            get { return (ICommand) GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }
        public Command DeleteSearchCommand { get; private set; }
    }
