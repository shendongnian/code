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
    
    namespace WpfApplication3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                //create a new viewModel
                MyViewModel1 dataContext = new MyViewModel1();
                dataContext.DataRows = new List<MyDataRow1>();
                
                
                //create the datarows (you have to read your file here instead of adding 10 rows ;-)
                for (int i = 0; i < 10; i++)
                {
                    dataContext.DataRows.Add( new MyDataRow1() { A = "öasldkfj" , B="aösldkfj", C="sdkljgfskn", D="asdfasdf"});
                }
               
                DataContext = dataContext;
            }
        }
        /// <summary>
        /// This is the ViewModel it provides Data data you can bind to from the UI
        /// </summary>
        public class MyViewModel1
        {
            /// <summary>
            /// Gets or sets the data rows.
            /// </summary>
            /// <value>The data rows.</value>
            public List<MyDataRow1> DataRows { get; set; }
        }
    
        public class MyDataRow1
        {
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
            public string D { get; set; }
        }
    }
