    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace PassValuesBetweenForms_43923548
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                CreateTextBox();
                CreateSubmitButton();
            }
    
            private void CreateSubmitButton()
            {
                Button btn = new Button();
                btn.Text = "click me";
                btn.Click += ClickMeGotClicked;
                btn.Location = new Point(5, 25);
                this.Controls.Add(btn);
            }
    
            private void ClickMeGotClicked(object sender, EventArgs e)
            {
                string theText = ((TextBox)this.Controls["txtbx"]).Text;
                Form2 form2 = new Form2(theText);//call the parametized constructor
                form2.Show();
            }
    
            private void CreateTextBox()
            {
                TextBox tb = new TextBox();
                tb.Location = new Point(5, 5);
                tb.Width = 50;
                tb.Name = "txtbx";
                this.Controls.Add(tb);
            }
        }
    }
    
