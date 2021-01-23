    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            Timer timer;
            Form form;
            RichTextBox richTextBox;
            public Form1()
            {
                //InitializeComponent();
                form = new Form
                {
                    Size = new Size(50, 20),
                    FormBorderStyle = FormBorderStyle.None,
                    TopMost = true,
                    ShowInTaskbar = false
                };
                richTextBox = new RichTextBox { Parent = form, Dock = DockStyle.Fill };
                timer = new Timer { Interval = 10, Enabled = true };
                timer.Tick += Timer_Tick;
                form.Show();
            }
            private void Timer_Tick(object sender, EventArgs e)
            {
                form.Location = new Point(MousePosition.X + 10, MousePosition.Y - 20);
            }
        }
    }
