    public partial class Window1 : Window
    {
        public event EventHandler<NameAddedEventArgs> ItemAddedEvent;
        public Window1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseNewNameEvent(txtInput.Text);
        }
        protected void RaiseNewNameEvent(string newName)
        {
            var nameAddedEventArgs = new NameAddedEventArgs { NewName=newName };
            var handler = ItemAddedEvent;
            if (handler != null)
            {
                handler(this, nameAddedEventArgs);
            }
        }
    }
