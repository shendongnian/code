    public class CommandHamburgerMenu : FrameworkElement, ICommand
    {
        public CommandHamburgerMenu()
        {
            ItemChanged(this, new DependencyPropertyChangedEventArgs(CommandHamburgerMenu.ItemProperty, null, null));
        }
        public HamburgerMenuItem Item
        {
            get { return (HamburgerMenuItem)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }
        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register("Item", typeof(HamburgerMenuItem), typeof(CommandHamburgerMenu), new UIPropertyMetadata(null, new PropertyChangedCallback(ItemChanged)));
        private static void ItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandHamburgerMenu commandHamburgerMenu = (CommandHamburgerMenu)d;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            if (this.Item != null)
            {
                if (this.Item == MainWindow.Instance.itemHome) MessageBox.Show("Home item");
                else if (this.Item == MainWindow.Instance.itemSearch) MessageBox.Show("Search item");
                else MessageBox.Show("Other");
            }
            else
            {
                MessageBox.Show("Item is null!");
            }
        }
    }
