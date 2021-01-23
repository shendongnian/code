    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace StackOverflowBinding
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            // Dependency Property
            public static readonly DependencyProperty ExecutionTimeAverageProperty =
                 DependencyProperty.Register("ExecutionTimeAverage", typeof(DateTime),
                 typeof(MainWindow), new FrameworkPropertyMetadata(DateTime.Now));
    
            // .NET Property wrapper
            public DateTime ExecutionTimeAverage
            {
                get { return (DateTime)GetValue(ExecutionTimeAverageProperty); }
                set { SetValue(ExecutionTimeAverageProperty, value); }
            }
    
            // Dependency Property
            public static readonly DependencyProperty ThreadsAvailableCountProperty =
                 DependencyProperty.Register("ThreadsAvailableCount", typeof(int),
                 typeof(MainWindow), new FrameworkPropertyMetadata(40));
    
            // .NET Property wrapper
            public int ThreadsAvailableCount
            {
                get { return (int)GetValue(ThreadsAvailableCountProperty); }
                set { SetValue(ThreadsAvailableCountProperty, value); }
            }
        }
    }
