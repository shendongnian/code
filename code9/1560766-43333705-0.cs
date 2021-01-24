        namespace WinForm
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                    // Apply font from the properties settings
                    fontLabel.Font = WinForm.Properties.Settings.Default.evFont;
                }
            }
        }
