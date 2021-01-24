        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                listBox1.Items.AddRange(new Object[] { "TextBox" });
                tableLayoutPanel1.AllowDrop = true;
                tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
                tableLayoutPanel1.AutoScroll = true;
                tableLayoutPanel1.RowStyles.Clear();
                tableLayoutPanel1.ColumnStyles.Clear();
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            }
    
            private void listBox1_MouseDown(Object sender, MouseEventArgs e)
            {
                var count = tableLayoutPanel1.Controls.Count;
                DoDragDrop($"test{count + 1}", DragDropEffects.Copy);
            }
    
            private void tableLayoutPanel1_DragEnter(Object sender, DragEventArgs e)
            {
                e.Effect = DragDropEffects.Copy;
            }
    
            private void tableLayoutPanel1_DragDrop(Object sender, DragEventArgs e)
            {
                var tb = new TextBox();
                tb.Dock = DockStyle.Fill;
                tb.Text = (e.Data.GetData(typeof(String)) as String);
    
                var newRow = tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                var ctrl = tableLayoutPanel1.GetChildAtPoint(tableLayoutPanel1.PointToClient(new Point(e.X, e.Y)));
                if (ctrl != null)
                {
                    var pos = tableLayoutPanel1.GetRow(ctrl);
                    for (Int32 i = tableLayoutPanel1.RowStyles.Count - 2; i >= pos; i--)
                    {
                        var c = tableLayoutPanel1.GetControlFromPosition(0, i);
                        if (c != null)
                            tableLayoutPanel1.SetRow(c, i + 1);
                    }
                    tableLayoutPanel1.Controls.Add(tb, 0, pos);
                }
                else
                    tableLayoutPanel1.Controls.Add(tb, 0, newRow);
            }
        }
