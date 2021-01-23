    public partial class UserControl1
    {
        public UserControl1()
        {
            InitializeComponent();
            listBox.ItemsSource = new List<object>
                {
                    new Employee("Donald Duck"),
                    new Certifying("Mickey Mouse", DateTime.Now),
                    new Employee("Napoleon Bonaparte"),
                    new Certifying("Homer Simpson", DateTime.Now - TimeSpan.FromDays(2)),
                };
        }
    }
