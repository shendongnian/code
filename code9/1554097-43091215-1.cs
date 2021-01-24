    using Xamarin.Forms;
    
    namespace TestRelativeLayout
    {
    	public partial class MyPage1 : ContentPage
    	{
    		public MyPage1()
    		{
    			InitializeComponent();
    		}
    
    		public void Handle_Clicked(object sender, System.EventArgs e)
    		{
    			Application.Current.MainPage = new NavigationPage(new MyPage2());
    		}
    	}
    }
