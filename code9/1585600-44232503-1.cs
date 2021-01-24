    public partial class MetroWindow : Window
    {
        public MetroWindow()
        {
            InitializeComponents();
            DataContext = Sesion.Instance;
        }
    }
