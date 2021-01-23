    class MyForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCLBUTTONDOWN:
                    TakeFocus();
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        private void TakeFocus()
        {
            if (Owner == null && OwnedForms.Length > 0)
            {
                Form tmp = OwnedForms[0];
                tmp.Owner = null;
                Owner = tmp;
            }
            BringToFront();
        }
        static void Main(string[] args)
        {
            MyForm f1 = new MyForm()
            {
                Text = "f1",
            };
            f1.Show();
            MyForm f2 = new MyForm()
            {
                Text = "f2",
            };
            f2.Owner = f1;
            f2.Show();
            Button b1 = new Button();
            b1.Click += (sender, e) =>
            {
                f1.TakeFocus();
            };
            f1.Controls.Add(b1);
            Button b2 = new Button();
            b2.Click += (sender, e) =>
            {
                f2.TakeFocus();
            };
            f2.Controls.Add(b2);
            Application.Run(f1);
        }
    }
