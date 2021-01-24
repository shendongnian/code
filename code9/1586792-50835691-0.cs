    public class()
            {     
                this.InitializeComponent();
                MaximizeWindowOnLoad();   
            }
    private static void MaximizeWindowOnLoad()
            { 
               ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
            }
