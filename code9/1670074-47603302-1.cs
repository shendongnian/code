    public partial class SomeForm : Window
    {
        public SomeForm()
        {
            InitializeComponent();
            Meta.StaticPropertyChanged += MethodThatTriggersOnUpdate;
            ...
        }
        private void MethodThatTriggersOnUpdate(object sender, EventArgs e)
        {
            myImage.Dispatcher.BeginInvoke(
                (Action)(() => myImage.Source = new BitmapImage(
                new Uri("/MyProject;component/Images/myNewImage.gif", UriKind.Relative))));
        }
        ...
    }
