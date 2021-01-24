    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace ShowHideButtons_47439046
    {
        public partial class Form1 : Form
        {
            ComboBox combo = new ComboBox();
    
            Button btn1 = new Button();
            Button btn2 = new Button();
            Button btn3 = new Button();
            Button btn4 = new Button();
            Button btn5 = new Button();
    
            TextBox txtbx1 = new TextBox();
            TextBox txtbx2 = new TextBox();
            TextBox txtbx3 = new TextBox();
            TextBox txtbx4 = new TextBox();
            TextBox txtbx5 = new TextBox();
    
            public Form1()
            {
                InitializeComponent();
    
                InitOurThings();
            }
    
            private void InitOurThings()
            {
                combo.Location = new Point(5, 5);
                combo.Items.Add(1);
                combo.Items.Add(2);
                combo.Items.Add(3);
                combo.Items.Add(4);
                combo.Items.Add(5);
                combo.SelectedValueChanged += Combo_SelectedValueChanged;
                this.Controls.Add(combo);
    
                btn1.Text = "btn1";
                btn1.Location = new Point(5, combo.Location.Y + combo.Height + 5);
                btn1.Name = "1";
                this.Controls.Add(btn1);
                txtbx1.Location = new Point(btn1.Location.X + btn1.Width + 5, btn1.Location.Y);
                txtbx1.Name = "1";
                this.Controls.Add(txtbx1);
    
                btn2.Text = "btn2";
                btn2.Location = new Point(5, btn1.Location.Y + btn1.Height + 5);
                btn2.Name = "2";
                this.Controls.Add(btn2);
                txtbx2.Location = new Point(btn2.Location.X + btn2.Width + 5, btn2.Location.Y);
                txtbx2.Name = "2";
                this.Controls.Add(txtbx2);
    
                btn3.Text = "btn3";
                btn3.Location = new Point(5, btn2.Location.Y + btn2.Height + 5);
                btn3.Name = "3";
                this.Controls.Add(btn3);
                txtbx3.Location = new Point(btn3.Location.X + btn3.Width + 5, btn3.Location.Y);
                txtbx3.Name = "3";
                this.Controls.Add(txtbx3);
    
                btn4.Text = "btn4";
                btn4.Location = new Point(5, btn3.Location.Y + btn3.Height + 5);
                btn4.Name = "4";
                this.Controls.Add(btn4);
                txtbx4.Location = new Point(btn4.Location.X + btn4.Width + 5, btn4.Location.Y);
                txtbx4.Name = "4";
                this.Controls.Add(txtbx4);
    
                btn5.Text = "btn5";
                btn5.Location = new Point(5, btn4.Location.Y + btn4.Height + 5);
                btn5.Name = "5";
                this.Controls.Add(btn5);
                txtbx5.Location = new Point(btn5.Location.X + btn5.Width + 5, btn5.Location.Y);
                txtbx5.Name = "5";
                this.Controls.Add(txtbx5);
            }
    
            private void Combo_SelectedValueChanged(object sender, EventArgs e)
            {
    
                int selectedValue = int.Parse(((ComboBox)sender).SelectedItem.ToString());
    
                foreach (Control item in Controls)
                {
                    //show/hide the controls based on their Name being Equal Or Smaller than the selectedItem
                    if (item is TextBox)
                    {
                        int itemNumber = int.Parse(item.Name);
                        item.Visible = itemNumber <= selectedValue ? true : false;
                    }
                    if (item is Button)
                    {
                        int itemNumber = int.Parse(item.Name);
                        item.Visible = itemNumber <= selectedValue ? true : false;
                    }
                }
            }
        }
    }
