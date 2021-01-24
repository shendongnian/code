    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new
            {
                VmObj_1 = new VM1 { TabID = "01", TabHeader = "one" },
                VmObj_2 = new VM1 { TabID = "02", TabHeader = "two" },
                VmObj_3 = new VM2 { TabID = "02", TabHeader = "three" },
                VmObj_4 = new VM2 { TabID = "03", TabHeader = "four" },
            };
        }
    }
    public class VMBase
    {
        public string TabID { get; set; }
        public string TabHeader { get; set; }
    }
    public class VM1 : VMBase { }
    public class VM2 : VMBase { }
