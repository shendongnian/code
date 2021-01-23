    public partial class MainPage : MasterDetailPage
    	{
    		public MainPage()
    		{
    			InitializeComponent();
    		}
    
    		void OnButtonClick(object sender, EventArgs e)
    		{
                // hide master page
    			this.IsPresented = false;
                // show master page
    			this.IsPresented = true;
    		}
    	}
