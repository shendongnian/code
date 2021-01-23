    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace SO40212766
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
    
          ButtonsList = new ObservableCollection<Button>();
        }
    
        public static RoutedUICommand AddNewButton = new RoutedUICommand("Add Button", "AddNewButton", typeof(MainWindow));
    
        public ObservableCollection<Button> ButtonsList { get; private set; }
    
        private void AddNewButtonBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
          e.CanExecute = true;
        }
    
        int index = 1;
        private void AddNewButtonBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
          // You will of course set the command og click event on the button here...
          ButtonsList.Add(new Button() { Content = $"Button {index++}" });
        }
      }
    }
