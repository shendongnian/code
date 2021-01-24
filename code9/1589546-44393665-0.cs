    public partial class ImageViewer : Form
    {
        public ImageViewer()
        {
            InitializeComponent();
        }
        public delegate void dlgImageChecked(ImageViewer sender, string message);
        public event dlgImageChecked ImageChecked;
        private void cboxToSave_CheckedChanged(object sender, EventArgs e)
        {
            if (ImageChecked != null)
            {
                ImageChecked(this, (cboxToSave.Checked ? "Added: " : "Removed: ") + txFileName.Text);
            }
        }
    }
