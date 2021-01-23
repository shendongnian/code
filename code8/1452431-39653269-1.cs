    public partial class SelectSchool : ContentPage
    {
        public SelectSchool()
        {
            InitializeComponent();
            #region toolbar
            ToolbarItem tbi = null;
            if (Device.OS == TargetPlatform.Android)
            {
                tbi = new ToolbarItem("+", "plus", async () =>
                {
                    var target_page = new AddSchool();
                    target_page.PopupClosed += () => { /*Do something here*/ };
                    Navigation.PushModalAsync(target_page);
                }, 0, 0);
            }
            ToolbarItems.Add(tbi);
            #endregion
    
            this.Title = "Select School";
    
        }
    }
