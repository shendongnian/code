    using System.Windows;
    
    using FriendAssemblyTestLibrary;
    
    namespace FriendAssemblyTest
    {
    	public partial class MainWindow : Window
    	{
    		public MainWindow()
    		{
    			InitializeComponent();
    
    			GlobalData.GlobalData.Member = "hi";
    			GlobalData.GlobalData.TestDecimal = 3.67M;
    
    			var x = new Class1();
    		}
    	}
    }
