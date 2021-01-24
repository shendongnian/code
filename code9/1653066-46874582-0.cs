    using System;
    using System.Windows.Forms;
    namespace HandleSaizeChanged
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                SizeChanged += Form1_SizeChanged;
            }
            private void Form1_SizeChanged(object sender, EventArgs e)
            {
                // Handle data based on new Form size
            }
            protected override void OnSizeChanged(EventArgs e)
            {
                base.OnSizeChanged(e);
                // Handle data based on new Form size
            }
        }
    }
