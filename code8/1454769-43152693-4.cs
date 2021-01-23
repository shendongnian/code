	public partial class MainPage : PhoneApplicationPage
    {
		ObservableCollection<SpeedDial> speedDialList = new ObservableCollection<SpeedDial>();
        // Constructor
        public MainPage()
        {
           
            InitializeComponent();
            speedDialList = new ObservableCollection <SpeedDial>();
            speedDialList.Add(new SpeedDial() { Names = "deepu", Photo =  new Uri("Image/2.jpg",UriKind.Relative) });
            speedDialList.Add(new SpeedDial() { Names = "jilu", Photo =  new Uri("Image/3.jpg",UriKind.Relative) });
            speedDialList.Add(new SpeedDial() { Names = "tinu", Photo =  new Uri("Image/4.jpg",UriKind.Relative) });
            speedDialList.Add(new SpeedDial() { Names = "jhd", Photo = new Uri("Image/7.jpg",UriKind.Relative) });
            speedDialList.Add(new SpeedDial() { Names = "jose", Photo = new Uri("image/1.jpg",UriKind.Relative) });
            speedDialList.Add(new SpeedDial() { Names = "hgscf", Photo =  new Uri("image/2.jpg",UriKind.Relative) });
            speedDialList.Add(new SpeedDial() { Names = "hjsg", Photo =  new Uri("Image/5.jpg",UriKind.Relative) });
            speedDialList.Add(new SpeedDial() { Names = "jhvdj", Photo =  new Uri("Image/6.jpg" ,UriKind.Relative) });
            speedDialList.Add(new SpeedDial() { Names = "jhd", Photo =  new Uri("Image/7.jpg",UriKind.Relative) }); 
            speedDialList.Add(new SpeedDial() { Names = "jkgh", Photo =  new Uri("Image/4.jpg",UriKind.Relative) });
            speedDialList.Add(new SpeedDial() { Names = "kigh", Photo =  new Uri("Image/3.jpg",UriKind.Relative) });
            LLs.ItemsSource = speedDialList;
        }
	}
	}}
