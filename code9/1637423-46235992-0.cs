    /// <summary>
    /// Interaction logic for UC1.xaml
    /// </summary>
    public partial class UC1 : UserControl
    {
        private static List<UC1> _allInstanceOfThisControl = new List<UC1>();
        ViewModelUC1 vm = new ViewModelUC1();
        public UC1()
        {
            InitializeComponent();
            this.DataContext = vm;
            _allInstanceOfThisControl.Add(this);
            this.Unloaded += UC1_Unloaded;
        }
        private void UC1_Unloaded(object sender, RoutedEventArgs e)
        {
            _allInstanceOfThisControl.Remove(this);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (vm.IsTrue)
            {
                vm.IsTrue = false;
            }
            else
            {
                vm.IsTrue = true;
            }
            var _allInstanceOfThisControlExceptthis = _allInstanceOfThisControl.Where(s => s != this).ToList();
            _allInstanceOfThisControlExceptthis.ForEach(s =>
            {
                (s.DataContext as ViewModelUC1).IsTrue = vm.IsTrue;
            });
        }
