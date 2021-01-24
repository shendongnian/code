    public partial class WebColors : Form
    {
        public WebColors()
        {
            InitializeComponent();
        }
        public Color pick { get; set; }
        private void WebColors_Load(object sender, EventArgs e)
        {
            var webColors =
              Enum.GetValues(typeof(KnownColor))
                .Cast<KnownColor>()
                .Where(k => k >= KnownColor.Transparent && k < KnownColor.ButtonFace)
                .Select(k => Color.FromKnownColor(k))
                .OrderBy(c => c.GetHue())
                .ThenBy(c => c.GetSaturation())
                .ThenBy(c => c.GetBrightness()).ToList();
            int cc = webColors.Count;
            int n =  (int)Math.Sqrt(cc) + 0;
            int w = ClientSize.Width / (n) - 1;
            Height = (n+1) * w + 90;
            for (int i = 0; i < cc; i++)
            {
                Label lbl = new Label();
                lbl.Text = "";
                lbl.AutoSize = false;
                lbl.Size = new Size(w - 1, w - 1);
                lbl.BackColor = webColors[i];
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.Location = new Point(1 +  w * (i  % (n+ 1)) , w * ( i / (n+1)) );
                lbl.Click += (ss, ee) =>
                {
                    pick = lbl.BackColor;
                    lbl_colorName.Text = pick.Name;
                };
                Controls.Add(lbl);
            }
        }
        private void cb_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void cb_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
