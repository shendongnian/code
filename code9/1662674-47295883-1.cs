    using Xamarin.Forms;
    
    namespace A
    {
    	public partial class SubPage : ContentPage
    	{
    		public static SubPageViewModel BindingContextDummyInstance => null; // <------ added
    
    		public SubPage ()
    		{
    			InitializeComponent ();
    		}
    	}
    }
