    public partial class InvisibleFrame : Form
        {
            public InvisibleFrame()
            {
                InitializeComponent();
                BackColor = Color.Lime;
                TransparencyKey = Color.Lime;
                FormBorderStyle = FormBorderStyle.None;
                ShowInTaskbar = false;
            }
        }
