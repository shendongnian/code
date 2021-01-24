    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            const int WM_SYSCOMMAND = 0x112;
            const int SC_MAXIMIZE = 0xF030;
            const int SC_MAXIMIZE2 = 0xF032;
            protected override void WndProc(ref Message m)
            {
                if ((m.Msg == WM_SYSCOMMAND && m.WParam == new IntPtr(SC_MAXIMIZE)) || m.WParam == new IntPtr(SC_MAXIMIZE2))
                {
                    this.Size = this.MaximumSize;
                    m.Result = new IntPtr(0);
                    //base.WndProc(ref m);
                    //Eat the message so won't process further
                }
                else
                {
                    m.Result = new IntPtr(0);
                    base.WndProc(ref m);
                }
            }
        }
    }
