    namespace XamarinFormsBench
    {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryDetailView : ContentView
    {
        public SummaryDetailView()
        {
            InitializeComponent();
            toggle.PropertyChanged += Toggle_PropertyChanged;
            UpdateVisibility();
        }
        private void Toggle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsToggled")
            {
                UpdateVisibility();
            }
        }
        private void UpdateVisibility()
        {
            bool isDetail = toggle.IsToggled;
            addend1.IsVisible = isDetail;
            addend2.IsVisible = isDetail;
            result.IsVisible = isDetail;
            summary.IsVisible = !isDetail;
            InvalidateLayout();  // this is key!
        }
    }
    }
