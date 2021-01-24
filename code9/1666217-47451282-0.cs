        TextBox txtBox1 = new TextBox();
        private int subItemIndex = 0;
        private ListViewItem viewItem;
    
        private int? xpos = null;
        private void listView_Click(object sender, EventArgs e)
        {
            xpos = MousePosition.X - listView.PointToScreen(Point.Empty).X;
        } 
        public MainForm()
        {
            InitializeComponent();
            listView.Controls.Add(txtBox1);
            txtBox1.Visible = false;
            txtBox1.KeyPress += (sender, args) =>
            {
                TextBox textBox = sender as TextBox;
                
                if ((int)args.KeyChar == 13)
                {
                    if (viewItem != null)
                    {
                        viewItem.SubItems[subItemIndex].Text = textBox.Text;
                    }
                    textBox.Visible = false;
                }
            };
        }
            private void listView_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyData == Keys.F2 && listView.SelectedItems.Count > 0)
                {
                    viewItem = listView.SelectedItems[0];
                    var bounds = viewItem.Bounds;
                    var col2_bounds = viewItem.SubItems[1].Bounds;
                    var col1_bounds = viewItem.SubItems[0].Bounds;
                    col1_bounds.Width -= col2_bounds.Width;
    
    
                    if (xpos > col2_bounds.X)
                    {
                        subItemIndex = 1;
                        txtBox1.SetBounds(col2_bounds.X, bounds.Y, col2_bounds.Width, bounds.Height);
                    }
                    else
                    {
                        subItemIndex = 0;
                        txtBox1.SetBounds(col1_bounds.X, bounds.Y, col1_bounds.Width, bounds.Height);
                    }
                    txtBox1.Text = string.Empty;
                    txtBox1.Visible = true;
                }
            }
