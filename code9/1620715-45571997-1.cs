    namespace WpfApp1
    {
        using System.Collections.Generic;
        using System.Windows;
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public IEnumerable<MyObject> MyObjects
            {
                get
                {
                    yield return new MyObject { Template = "The parameter value is {0}", Parameter = "asdF1" };
                    yield return new MyObject { Template = "The parameter value is {0}", Parameter = "asdF2" };
                    yield return new MyObject { Template = "The parameter value is {0}", Parameter = "asdF3" };
                    yield return new MyObject { Template = "The parameter value is {0}", Parameter = "asdF4" };
                }
            }
        }
    }
