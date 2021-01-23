    public partial class MainPage : ContentPage
    {
        MyViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            vm = new MyViewModel();
            foreach (MyDataModel dm in vm.Data)
            {
                Image img = new Image();
                img.SetBinding(Image.SourceProperty, "MyImage", BindingMode.TwoWay, null, null);
                img.BindingContext = dm;
                Label label1 = new Label();
                label1.SetBinding(Label.TextProperty, "MyLabel", BindingMode.TwoWay, null, null);
                label1.BindingContext = dm;
                Label label2 = new Label();
                label2.SetBinding(Label.TextProperty, "Selected", BindingMode.TwoWay, null, null);
                label2.BindingContext = dm;
                StackLayout sl = new StackLayout();
                sl.Orientation = StackOrientation.Horizontal;
                sl.Children.Add(img);
                sl.Children.Add(label1);
                sl.Children.Add(label2);
                ViewCell vc = new ViewCell();
                vc.BindingContext = dm;
                vc.View = sl;
                vc.Tapped += Vc_Tapped;
                tableSection.Add(vc);
            }
        }
        private void Vc_Tapped(object sender, EventArgs e)
        {
            ViewCell vc = (ViewCell)sender;
            MyDataModel dm = (MyDataModel)vc.BindingContext;
            MyDataModel currSel = vm.Data.FirstOrDefault(d => d.Selected == true);
            if (currSel != null)
                currSel.Selected = false;
            dm.Selected = true;
        }
    }
