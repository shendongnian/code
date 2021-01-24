    using System.Text;
    *using System.Threading;*
    using System.Windows;
    
    namespace RdElectReg
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            *Progress viewModel = new Progress();*
    
            public MainWindow()
            {
                InitializeComponent();
                *this.DataContext = viewModel;*
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                */// Background thread Thread to run your logic 
                Thread thread = new Thread(YourLogicToUpdateTextBlock);
                thread.IsBackground = true;
                thread.Start();*
            }
            *// https://stackoverflow.com/questions/38477276/updating-value-of-textblock-in-wpf-dynamically-sovled*
            private void YourLogicToUpdateTextBlock()
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= 1000; i++)
                {
                    viewModel.Textstr = viewModel.Textstr + "Processing iteration " + i.ToString() + "\n";
                    sb.Append(ProcessFile(i));
                }
                viewModel.Textstr = viewModel.Textstr + "DONE\n";
            }
    
            private StringBuilder ProcessFile(int i)
            {
                StringBuilder sb1 = new StringBuilder();
    
                for (int j = 1; j < 10000; j++) {
                    sb1.Append(j.ToString() + ",");
                    sb1.Append(j.ToString() + ",");
                    sb1.Append(j.ToString() + ",");
                    sb1.Append(j.ToString() + ",");
                    sb1.Append(j.ToString() + ",");
                    sb1.Append(j.ToString() + ",");
                    sb1.Append(j.ToString() + ",");
                    sb1.Append(j.ToString() + ",");
                    sb1.Append(j.ToString() + ",");
                    sb1.Remove(sb1.Length - 1, 1);
                    sb1.AppendLine();
                }
    
                return sb1;
            }
        }
    }
