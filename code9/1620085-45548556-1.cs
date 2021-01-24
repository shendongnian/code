        using System.Text;
        using System.Windows;
    
        namespace RdElectReg
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
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i <= 10000; i++)
                {
                    sb.Append(ProcessFile(i));
                }
            }
    
             private StringBuilder ProcessFile(int i)
            {
                StringBuilder sb1 = new StringBuilder();
                string TextBlockText = Output.Text;
                TextBlockText = TextBlockText + "Processing iteration " + i.ToString() + "\n";
                // this property
                Output.Text = TextBlockText;
    
                for (int j = 1; j < 1000; j++) {
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
