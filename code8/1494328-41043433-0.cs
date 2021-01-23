    public partial class Create : Window
    {
    public Create()
    {
        InitializeComponent();
    }
    Save obj = new Save();
    private void addChoice1_Click(object sender, RoutedEventArgs e)
    {
        choice2.Visibility = Visibility.Visible;
        addChoice2.Visibility = Visibility.Visible;
        addChoice1.Visibility = Visibility.Hidden;
        
        obj.rbChoice2.Visibility = Visibility.Visible;
        obj.rbChoice2.Content = choice2.Text;
    }
    private void save_Click(object sender, RoutedEventArgs e)
    {
        obj.lbTest.Content = question.Text;
        obj.rbChoice1.Content = choice1.Text;
        obj.rbChoice2.Content = choice2.Text;
        obj.ShowDialog();
    }
    }
