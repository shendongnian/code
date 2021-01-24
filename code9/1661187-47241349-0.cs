    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainCarouselPage : CarouselPage
    {
        public MainCarouselPage()
        {
            InitializeComponent();
            for(int i=1; i< 3; i++)
            {
                Children.Add(new CarouselContentPage(i));
            }
            Title = "Carousel Page";
        }
    }
