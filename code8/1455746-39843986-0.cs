    enter public partial class Window1 : Window, INotifyPropertyChanged{
    public Window1(){   
	ProgressBarViewModel pbvm = new ProgressBarViewModel();
        InitializeComponent();
        DataContext = pbvm;
    }}
