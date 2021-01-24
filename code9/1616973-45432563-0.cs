    public partial class MainWindow : Window
    {
    public MainWindow()
    {
        InitializeComponent();
    }
    protected override void OnDeactivated(EventArgs e)
    {
        base.OnDeactivated(e);
        Close();
    }
}
