    public class MyViewModel
    {
        public DataTable Test { get; set; }
    }
    public MyWindow()
    {
        InitializeComponent();
        var vm = new MyViewModel
                    {
                        Test = new DataTable
                            {
                                Columns = {"A", "B", "C"}
                            }
                    };            
        this.DataContext = vm;
    }
