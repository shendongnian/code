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
                addButton();
                addTextField();
                addChkbx();
            }
    
            private void addChkbx()
            {
                CheckBox chkbx = new CheckBox();
                chkbx.Location = new Point(this.Location.X + 35, this.Location.Y + 55);
                chkbx.Name = "thechkbx";
                this.Controls.Add(chkbx);
            }
    
            private void addTextField()
            {
                TextBox txtb = new TextBox();
                txtb.Name = "txtbx_thebox";
                txtb.Location = new Point(this.Location.X + 5, this.Location.X + 35);
                this.Controls.Add(txtb);
            }
    
            private void addButton()
            {
                Button btn = new Button();
                btn.Text = "ClickMe";
                btn.Click += Btn_Click;
                btn.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
                this.Controls.Add(btn);
            }
    
            private void Btn_Click(object sender, EventArgs e)
            {
                ((CheckBox)this.Controls.Find("thechkbx", true)[0]).Checked = File.Exists(((TextBox)this.Controls.Find("txtbx_thebox", true)[0]).Text);
            }
        }
    }
