    using System;
    using System.Windows;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private Random random = new Random();
            private ParentViewModel model;
            public MainWindow()
            {
                InitializeComponent();
    
                this.DataContext = this;
                this.model = new ParentViewModel();
                this.model.Color = new ColorViewModel();
            }
    
            public ParentViewModel Model
            {
                get { return model; }
                set
                {
                    model = value;
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                this.model.Color.Blue = (byte)random.Next(0, 255);
                this.model.Color.Green = (byte)random.Next(0, 255);
                this.model.Color.Red = (byte)random.Next(0, 255);
            }
        }
    }
