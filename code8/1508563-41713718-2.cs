    public partial class Form1 : Form
    {
        private IDesktopWallpaper Wallpaper;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Wallpaper = (IDesktopWallpaper)new DesktopWallpaper();
            uint monitorCount = Wallpaper.GetMonitorDevicePathCount();
            for (uint i = 0; i < monitorCount; i++)
            {
                lbMonitors.Items.Add(Wallpaper.GetMonitorDevicePathAt(i));
            }
        }
        private void lbMonitors_SelectedValueChanged(object sender, EventArgs e)
        {
            var path = (string)lbMonitors.SelectedItem;
            tbWallpaper.Text = Wallpaper.GetWallpaper(path);
        }
    }
