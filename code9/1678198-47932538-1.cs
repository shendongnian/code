    using System.Collections.Generic;
    using System.Windows;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private List<int> items;
    
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                this.items = new List<int>();
                this.items.AddRange(new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8, 9});
            }
    
            public List<int> Items
            {
                get
                {
                    return this.items;
                }
            }
        }
    }
