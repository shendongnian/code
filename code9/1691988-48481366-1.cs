      public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
            protected override void OnClosing(CancelEventArgs e)
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                  Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
                base.OnClosing(e);
            }
        }
