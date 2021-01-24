    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripServiceStatus : ToolStripStatusLabel
    {
        Timer _statusRefresh = null;
        public ToolStripServiceStatus() : base()
        {
            this.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            RefreshStatus();
        }
        void _statusRefresh_Tick(object sender, EventArgs e)
        {
            RefreshStatus();
        }
        public ServiceControllerStatus GetStatus()
        {
            using (var service = new ServiceController("MyService"))
            {
                return service.Status;
            }
        }
        public ServiceControllerStatus GetStatusInfo(out string statusText, out Color indicatorColor)
        {
            ServiceControllerStatus status = default(ServiceControllerStatus);
            try
            {
                status = GetStatus();
                switch (status)
                {
                    case ServiceControllerStatus.ContinuePending:
                        statusText = Properties.Resources.SERVICE_CONTINUE_PENDING;
                        indicatorColor = Color.Yellow;
                        break;
                    case ServiceControllerStatus.Paused:
                        statusText = Properties.Resources.SERVICE_PAUSED;
                        indicatorColor = Color.Yellow;
                        break;
                    case ServiceControllerStatus.PausePending:
                        statusText = Properties.Resources.SERVICE_PAUSE_PENDING;
                        indicatorColor = Color.Yellow;
                        break;
                    case ServiceControllerStatus.Running:
                        statusText = Properties.Resources.SERVICE_RUNNING;
                        indicatorColor = Color.Green;
                        break;
                    case ServiceControllerStatus.StartPending:
                        statusText = Properties.Resources.SERVICE_START_PENDING;
                        indicatorColor = Color.Yellow;
                        break;
                    case ServiceControllerStatus.Stopped:
                        statusText = Properties.Resources.SERVICE_STOPPED;
                        indicatorColor = Color.Red;
                        break;
                    case ServiceControllerStatus.StopPending:
                        statusText = Properties.Resources.SERVICE_STOP_PENDING;
                        indicatorColor = Color.Yellow;
                        break;
                    default:
                        statusText = default(String);
                        indicatorColor = default(Color);
                        break;
                }
            }
            catch
            {
                statusText = Properties.Resources.SERVICE_CANNOT_CONNECT;
                indicatorColor = Color.Red;
            }
            return status;
        }
        string _previousStatusText = "";
        public ServiceControllerStatus RefreshStatus()
        {
            if (_statusRefresh == null)
            {
                _statusRefresh = new Timer() { Interval = 1000 };
                _statusRefresh.Tick += new EventHandler(_statusRefresh_Tick);
            }
            _statusRefresh.Enabled = false;
            string statusText;
            Color indicatorColor;
            ServiceControllerStatus status = GetStatusInfo(out statusText, out indicatorColor);
            if (_previousStatusText != statusText)
            {
                Text = statusText;
                Image bmp = new Bitmap(Height, Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.FillEllipse(new SolidBrush(indicatorColor), new Rectangle(0, 0, Height - 1, Height - 1));
                }
                this.Image = bmp;
            }
            _statusRefresh.Enabled = (status != ServiceControllerStatus.Stopped && status != ServiceControllerStatus.Running && status != ServiceControllerStatus.Paused);
            return status;
        }
    }
