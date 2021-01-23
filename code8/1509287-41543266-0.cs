    public partial class exampleWindow : Window 
    {
         public exampleWindow () 
         {
              InitializeComponent();
              DataContext = this;      
         }
	     public bool IsUsernameAndPasswordValid
	     {
		     get { return (String.IsNullOrEmpty(UsernameText) && String.IsNullOrEmpty(PasswordText)) ; }
	     }
    }
