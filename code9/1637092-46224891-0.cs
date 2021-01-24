    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace ChangeLastChar_46223845
    {
        public partial class Form1 : Form
        {
            TextBox txtbx_input = new TextBox();
            TextBox txtbx_result = new TextBox();
            Button btn = new Button();
            Button anotherBtn = new Button();
    
            public Form1()
            {
                InitializeComponent();
                AddOurStuffToTheForm();
    
                PutDefaultWordInInputBox();
            }
    
            private void PutDefaultWordInInputBox()
            {
                txtbx_input.Text = "Krazys";
            }
    
            private void AddOurStuffToTheForm()
            {
                txtbx_input.Location = new Point(5, 5);
                btn.Location = new Point(5, txtbx_input.Location.Y + txtbx_input.Height + 5);
                anotherBtn.Location = new Point(5, btn.Location.Y + btn.Height + 5);
                txtbx_result.Location = new Point(5, anotherBtn.Location.Y + anotherBtn.Height + 5);
    
                btn.Text = "Substring";
                btn.Click += Btn_Click;
                anotherBtn.Click += AnotherBtn_Click;
                anotherBtn.Text = "Replace";
    
                this.Controls.Add(txtbx_input);
                this.Controls.Add(btn);
                this.Controls.Add(anotherBtn);
                this.Controls.Add(txtbx_result);
    
            }
    
            private void AnotherBtn_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(txtbx_input.Text) || string.IsNullOrWhiteSpace(txtbx_input.Text))
                {
                    return;   
                }
    
                if (txtbx_input.Text.EndsWith("ys"))
                {
                    txtbx_result.Text = "Hello " + txtbx_input.Text.Replace("ys", "y");
                }
            }
    
            private void Btn_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(txtbx_input.Text) || string.IsNullOrWhiteSpace(txtbx_input.Text))
                {
                    return;
                }
                if (txtbx_input.Text.EndsWith("ys"))
                {
                    txtbx_result.Text = "Hello " + txtbx_input.Text.Substring(0, txtbx_input.Text.Length - 1);
                }
            }
        }
    }
