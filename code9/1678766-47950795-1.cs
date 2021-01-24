    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MyDataContext();
            }
    
            public class MessageCommand : ICommand    
            {
                public void Execute(object parameter)
                {
                    string msg;
    
                    if (parameter == null)
                        msg = "Button Clicked!";
                    else
                        msg = parameter.ToString();
    
                    MessageBox.Show(msg);
                }
    
                public bool CanExecute(object parameter)
                {
                    return true;
                }
    
                public event EventHandler CanExecuteChanged;
            }
    
            public class MyDataContext
            {
                ICommand _messageCommand = new MessageCommand();
    
                public ICommand MessageCommand
                {
                    get { return _messageCommand; }
                }
            }
        }
    }
