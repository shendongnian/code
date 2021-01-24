    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                // only run this code in RunTime
                if (LicenseManager.UsageMode == LicenseUsageMode.Runtime)
                {
                    // load some data
                    LoadData();
                }
                // only call the OnLoad event if there is no exception when loading the data of the base form
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                // handle the exception and tell the user something BUT don't kill the app... a THROW here could kill the app
                HandleException(ex);
                // close the forms
                this.Close();
            }
        }
        private void BaseForm_Load(object sender, EventArgs e)
        {
            // NOTE: any exception handled here will still cause the inherited forms Load event to fire
        }
    }
