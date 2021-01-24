    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    
    namespace AutoCheckCheckbxIfFileExist_45245562
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                /*
                 * I'm adding the fields dynamically through code so that
                 * you know all the fields that are on my form.
                 * Because they are created dynamically, I'll use 'Find' later on
                 * to retrieve them.
                 */
                addButton();
                addTextField();
                addChkbx();
            }
    
            private void addChkbx()
            {
    
                /*
                 * This is the checkbox that will be dyamically checked or unchecked
                 */
                CheckBox chkbx = new CheckBox();
                chkbx.Location = new Point(this.Location.X + 35, this.Location.Y + 55);
                chkbx.Name = "thechkbx";
                this.Controls.Add(chkbx);
            }
    
            private void addTextField()
            {
                /*
                 * This is the field I'll be looking at to pull the file path
                 */
                TextBox txtb = new TextBox();
                txtb.Name = "txtbx_thebox";
                txtb.Location = new Point(this.Location.X + 5, this.Location.X + 35);
                this.Controls.Add(txtb);
            }
    
            private void addButton()
            {
                /*
                 * This will be the button you'll click on to get the check/uncheck behavior
                 */
                Button btn = new Button();
                btn.Text = "ClickMe";
                btn.Click += Btn_Click;
                btn.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
                this.Controls.Add(btn);
            }
    
            private void Btn_Click(object sender, EventArgs e)
            {
                /*
                 * This is the answer to your question
                 * Because I dynamically create the fields, I'm using a Find to get them and use them.
                 */
                ((CheckBox)this.Controls.Find("thechkbx", true)[0]).Checked = File.Exists(((TextBox)this.Controls.Find("txtbx_thebox", true)[0]).Text);
    
    
            }
        }
    }
