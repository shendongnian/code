    public sealed partial class MainPage
    {
    	public MainPage()
    	{
    		InitializeComponent();
    
    		var dismissal = new TimePickerDismissal(MyTimePicker);
    
    		dismissal.Dismissed += OnTimerDismissed;
    	}
    
    	private void OnTimerDismissed(object sender, EventArgs e)
    	{
    		Debug.WriteLine("TimePicker dismissed!");
    	}
    }
