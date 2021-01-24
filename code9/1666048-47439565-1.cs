    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace ShowHideButtons_47439046
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
    
                InitOurThings();
            }
    
            private void InitOurThings()
            {
                //lets create a combo box with options to select
                ComboBox combo = new ComboBox();
                combo.Location = new Point(5, 5);//place it somewhere
    
                //add selectable items
                for (int i = 0; i < 10; i++)
                {
                    combo.Items.Add(i);
                }
    
                combo.SelectedValueChanged += Combo_SelectedValueChanged;//the event which will handle the showing/hidding
                Controls.Add(combo);//add the combo box to the form
    
    
                //lets create some buttons and textboxes
                int btnx = 5;
                int btny = combo.Height + combo.Location.Y + 5;
                for (int i = 0; i < 10; i++)
                {
                    Button btn = new Button();
                    btn.Location = new Point(btnx, btny);
                    btn.Name = i.ToString();
                    btn.Text = i.ToString();
                    Controls.Add(btn);
                    btny += btn.Height + 5;
    
                    TextBox txtbx = new TextBox();
                    txtbx.Location = new Point(btn.Location.X + btn.Width + 5, btn.Location.Y);
                    txtbx.Name = i.ToString();
                    txtbx.Text = i.ToString();
                    Controls.Add(txtbx);
                }
    
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
