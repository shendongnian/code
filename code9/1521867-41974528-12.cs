    using System.Windows.Controls;
    namespace WpfPromholComplementary_1
    {
        public partial class MyModuleFrame : UserControl
        {
            public MyModuleFrame()
            {
                InitializeComponent();
                DataContext = this;
            }
            public string ModuleNumber { get; set; }
            public double Channel1 { get; set; }
            public double Channel2 { get; set; }
            public double Channel3 { get; set; }
            public double Channel4 { get; set; }
        }
    }
