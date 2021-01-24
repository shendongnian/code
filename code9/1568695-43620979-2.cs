    using System.Drawing;
    using System.Windows.Forms;
    
    
    namespace ListBox_15948283
    {
        public partial class Form1 : Form
        {
            private int ItemMargin = 5;
            private int labelCount = 0;
    
            public Form1()
            {
                InitializeComponent();
                ListBox lb = new ListBox();//initialize a new ListBox
                lb.DrawMode = DrawMode.OwnerDrawFixed;//lets meet YOUR requirement of OwnerDrawFixed
                lb.Location = new Point(25, 25);//position the ListBox
                lb.DrawItem += Lb_DrawItem;//give it a Draw event handler
                lb.MeasureItem += Lb_MeasureItem;//give it a MeasureItem event handler
                lb.Name = "lstbx_Yep";//give the listbox a name so we can call it later
                lb.Items.Add("Option 1");//add an option
                lb.Items.Add("Option 2");//add an option
                lb.Items.Add("Option 3");//add an option
                lb.Items.Add("Option 4");//add an option
                lb.MouseDoubleClick += Lb_MouseDoubleClick;//add a doubleClick event handler on the ListBox
                this.Controls.Add(lb);//add the listbox to the form
            }
    
            private void Lb_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                ListBox lb = ((ListBox)this.Controls.Find("lstbx_Yep", false)[0]);//get the listbox
                Label lbl = new Label();//make a label to display the result
                lbl.Location = new Point(150, (labelCount * 25) + 50);//position the label
                lbl.Text = lb.SelectedItem.ToString();//get the selected item
                this.Controls.Add(lbl);//add the label to the form
                labelCount++;
    
            }
    
            /*
             * Code below taken from
             * http://csharphelper.com/blog/2014/11/make-an-owner-drawn-listbox-in-c/
             */
            private void Lb_MeasureItem(object sender, MeasureItemEventArgs e)
            {
                // Get the ListBox and the item.
                ListBox lst = sender as ListBox;
                string txt = (string)lst.Items[e.Index];
    
                // Measure the string.
                SizeF txt_size = e.Graphics.MeasureString(txt, this.Font);
    
                // Set the required size.
                e.ItemHeight = (int)txt_size.Height + 2 * ItemMargin;
                e.ItemWidth = (int)txt_size.Width;
            }
    
            private void Lb_DrawItem(object sender, DrawItemEventArgs e)
            {
                // Get the ListBox and the item.
                ListBox lst = sender as ListBox;
                string txt = (string)lst.Items[e.Index];
    
                // Draw the background.
                e.DrawBackground();
    
                // See if the item is selected.
                if ((e.State & DrawItemState.Selected) ==
                    DrawItemState.Selected)
                {
                    // Selected. Draw with the system highlight color.
                    e.Graphics.DrawString(txt, this.Font,
                        SystemBrushes.HighlightText, e.Bounds.Left,
                            e.Bounds.Top + ItemMargin);
                }
                else
                {
                    // Not selected. Draw with ListBox's foreground color.
                    using (SolidBrush br = new SolidBrush(e.ForeColor))
                    {
                        e.Graphics.DrawString(txt, this.Font, br,
                            e.Bounds.Left, e.Bounds.Top + ItemMargin);
                    }
                }
    
                // Draw the focus rectangle if appropriate.
                e.DrawFocusRectangle();
            }
        }
    }
