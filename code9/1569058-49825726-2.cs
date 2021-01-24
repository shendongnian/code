    public partial class UserPage : ContentPage
    	{
    
            ObservableCollection<UserModel> Usr_List = new ObservableCollection<UserModel>();
    
            public UserPage ()
    		{
    			InitializeComponent ();
                //test data population
                this.Usr_List.Add(new UserModel { id = 1, usr = "test", pass = "test" });
                this.Usr_List.Add(new UserModel { id = 2, usr = "test1", pass = "test1" });
                this.Usr_List.Add(new UserModel { id = 3, usr = "test2", pass = "test2" });
    
                listx.ItemsSource = this.Usr_List;
    
            }
    	}
