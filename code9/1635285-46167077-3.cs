    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace ListViewSubItems
    {
        public partial class Form1 : Form
        {
    
            TextBox txtbx = new TextBox();//this will be the textbox in which the user will type something
            ListView lv = new ListView();//this will be our listview
            Button btn = new Button();//this will be our button
            Button btnChange = new Button();
            public Form1()
            {
                InitializeComponent();
                InitializeOurStuff();
                AddInitalEntriesAgain();
            }
    
            /// <summary>
            /// this is where the magic happens
            /// </summary>
            private void AddSubItems()
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
    
            /// <summary>
            /// In this method, we simply update a SubItem
            /// </summary>
            private void UpdateTheSubItem()
            {
                if (lv.Items.ContainsKey(txtbx.Text))
                {
                    if (lv.Items[txtbx.Text].SubItems.Count > 1)
                    {
                        lv.Items[txtbx.Text].SubItems[1].Text = "you just got replaced! " + txtbx.Text;
                    }
                }
            }
    
            /// <summary>
            /// For the purpose of this snippet
            /// Everything on the form is created in here
            /// NOTHING created using Designer
            /// </summary>
            private void InitializeOurStuff()
            {
                //set some textbox properties
                txtbx.Location = new Point(5, 5);
                txtbx.KeyUp += Txtbx_KeyUp;
    
                //set some ListView properties
                lv.Location = new Point(txtbx.Location.X, txtbx.Location.Y + txtbx.Height + 5);
                lv.HideSelection = false;
                lv.View = View.Details;
                lv.Width = this.Width - 20;
    
                //set some button properties
                btn.Location = new Point(lv.Location.X, lv.Location.Y + lv.Height + 5);
                btn.Text = "Add SubItms";
                btn.Click += Btn_Click;
    
                btnChange.Location = new Point(btn.Location.X + btn.Width + 5, btn.Location.Y);
                btnChange.Text = "Change SubItm";
                btnChange.Click += BtnChange_Click;
    
                //add the controls to the forms
                this.Controls.Add(txtbx);
                this.Controls.Add(lv);
                this.Controls.Add(btn);
                this.Controls.Add(btnChange);
            }
    
            private void BtnChange_Click(object sender, EventArgs e)
            {
                UpdateTheSubItem();
            }
    
            /// <summary>
            /// keyboard navigation for keyboard junkies
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
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
    
            /// <summary>
            /// I assume you have your own way of populating the listview
            /// though don't forget to add the initial column
            /// </summary>
            private void AddInitalEntriesAgain()
            {
                lv.Columns.Add("maincol");
                for (int i = 0; i < 5; i++)
                {
                    lv.Items.Add("key" + i, "value" + i, null);
                }
            }
    
            /// <summary>
            /// the button click event
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Btn_Click(object sender, EventArgs e)
            {
                AddSubItems();
            }
        }
    }
