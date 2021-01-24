    public partial class Form1 : Form
    {
        Panel pnlMain;
        Panel pnlSelect;
        public Form1()
        {
            InitializeComponent();
            //You will already have all of this - this is just to make a minimal-complete example without the designer.
            pnlSelect = new Panel();
            pnlMain = new Panel();
            this.Controls.AddRange(new Control[] { pnlSelect, pnlMain });
            pnlSelect.Dock = DockStyle.Left;
            pnlMain.Dock = DockStyle.Right;
            pnlSelect.Width = (int)(this.Width * 0.2);
            pnlMain.Width = this.Width - pnlSelect.Width - 25;
            for(int i=0;i<6;i++)
            {
                Button btn = new Button();
                btn.Name = i.ToString();
                btn.Text = i.ToString();
                pnlSelect.Controls.Add(btn);
                btn.Location = new Point(btn.Location.X, btn.Height * i + 5);
                btn.Click += Btn_Click;
            }
            //just to see a difference
            pnlMain.BackColor = Color.Green;
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            UserControl oCon = (from UserControl uc in pnlMain.Controls where uc.GetType() == typeof(UserControl) && uc.Name == btn.Name select uc).FirstOrDefault();
            if(oCon == null)
            {
                oCon = new UserControl();
                oCon.Name = btn.Name;
                pnlMain.Controls.Add(oCon);
                Label lbl = new Label();
                lbl.Text = oCon.Name;
                oCon.Controls.Add(lbl);
                //just to see a difference
                oCon.BackColor = Color.Blue;                
            }
            oCon.BringToFront();
            Console.WriteLine("pnlMain has: {0} Children.", pnlMain.Controls.Count.ToString());
        }
    }
