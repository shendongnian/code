    using System.Diagnostics;
    using System.Windows;
    
    namespace StopWatch
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
    
          public Stopwatch MyStopWatch = new Stopwatch();
    
          private void Start_Button_Click( object sender, RoutedEventArgs e )
          {
             MyStopWatch.Start();
          }
    
          private void Stop_Button_Click( object sender, RoutedEventArgs e )
          {
             MyStopWatch.Stop();
             MessageBox.Show( MyStopWatch.ElapsedMilliseconds.ToString() );
          }
       }
    }
