        public partial class DetayWindow : Window
    {
        public DetayWindow()
        {
            InitializeComponent();
        }
        public string baslik { get; set; }
        public string yazi { get; set; }
        public string tarih { get; set; }
        public string mevkii { get; set; }
        public string metrekare { get; set; }
        public string tur { get; set; }
        public string id { get; set; }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //textbox1.Text = sifre;
            //text1.Text = kullaniciAdi;
            idtext.Text = id;
            turtext.Text = tur;
            metrekaretext.Text = metrekare;
            konumtext.Text = mevkii;
            tarihtext.Text = tarih;
            yazitext.Text = yazi;
            basliktext.Text = baslik;
        }
    }
