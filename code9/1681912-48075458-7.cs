    public partial class RestaurantSinglePageDetails: ContentPage
    {
        Restaurant res;
        public RestaurantSinglePageDetails(Restaurant res)
        {
            InitializeComponent();
            BindingContext = new RestaurantDetailsViewModel(item); //now you have access to restaurant in your viewModel. In this way you don't need use BindingContext in XAML
            this.res = res; 
             
            //and here you have access to your selected restaurant. 
        }
    }
