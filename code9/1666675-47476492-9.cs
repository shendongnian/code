	public partial class PopupDemo : Rg.Plugins.Popup.Pages.PopupPage
    {
		private TaskCompletionSource<EnumAction> task;
		
        public PopupDemo(TaskCompletionSource<EnumAction> taskCompletion)
        {
            InitializeComponent();
            task = taskCompletion;
        }
    }
