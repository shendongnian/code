    [ContentProperty("ContainerContent")]
    public partial class ExpandCollapseStackLayout : ContentView
    {
        public ExpandCollapseStackLayout()
        {
            InitializeComponent();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                ContentFrame.IsVisible = !ContentFrame.IsVisible;
            };
            lblTitle.GestureRecognizers.Add(tapGestureRecognizer);
            slMain.GestureRecognizers.Add(tapGestureRecognizer);
        }
        public View ContainerContent
        {
            get { return ContentFrame.Content; }
            set { ContentFrame.Content = value; }
        }
        public string Title
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }
    }
    
