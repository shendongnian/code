    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace ListViewSubItems
    {
        public partial class Form1 : Form
        {
    
            TextBox txtbx = new TextBox();
            ListView lv = new ListView();
            Button btn = new Button();
            public Form1()
            {
                InitializeComponent();
                InitializeOurStuff();
                AddInitalEntriesAgain();
            }
    
    
            private void InitializeOurStuff()
            {
                txtbx.Location = new Point(5, 5);
                txtbx.KeyUp += Txtbx_KeyUp;
    
                lv.Location = new Point(txtbx.Location.X, txtbx.Location.Y + txtbx.Height + 5);
                lv.HideSelection = false;
                lv.View = View.Details;
                lv.Width = this.Width - 20;
    
                btn.Location = new Point(lv.Location.X, lv.Location.Y + lv.Height + 5);
                btn.Click += Btn_Click;
    
                this.Controls.Add(txtbx);
                this.Controls.Add(lv);
                this.Controls.Add(btn);
    
    
            }
    
            private void Txtbx_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Btn_Click(null, null);
                }
                else if (e.KeyCode == Keys.Q && e.Modifiers == Keys.Control)
                {
                    this.Close();
                }
            }
    
            private void AddInitalEntriesAgain()
            {
                lv.Columns.Add("maincol");
                for (int i = 0; i < 5; i++)
                {
                    lv.Items.Add("key" + i, "value" + i, null);
                }
            }
    
            private void AddEntries()
            {
                for (int i = 0; i < 10; i++)
                {
                    lv.Items.Add("key" + i, "value" + i, "");
                }
            }
    
            private void Btn_Click(object sender, EventArgs e)
            {
                HighlightAndReplace();
            }
    
            private void HighlightAndReplace()
            {
                if (string.IsNullOrEmpty(txtbx.Text))
                {
                    //nothing to do
                    return;
                }
    
                /*
                 * You can add SubItems all you want. 
                 * But you'll never see them unless you have column
                 * foreach of the SubItem you whish to show
                 * To do so, you need to keep track of 
                 * how many SubItems are listed per row,
                 * so that you append the SubItem to the right column,
                 * and so that you add a column only when needed
                 */
    
    
                if (lv.Items.ContainsKey(txtbx.Text))
                {
                    lv.Items[txtbx.Text].SubItems.Add("coolbeans");
                    lv.Items[txtbx.Text].SubItems.Add("COOLBEANS");
    
                    /*
                     * Again, if you don't have a column to host
                     * your SubItem, then your SubItem will simply not show up
                     * Having said that, now add as many columns as you need
                     */
                    while ((lv.Columns.Count) < lv.Items[txtbx.Text].SubItems.Count)
                    {
                        lv.Columns.Add("subcol" + lv.Columns.Count);
                    }
                }
            }
        }
    }
