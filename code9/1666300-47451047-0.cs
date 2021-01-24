    using System;
    using System.Windows.Forms;
    namespace MyApp
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.UnmanagedCode)]
        public class MyForm : Form, IMessageFilter
        {
            public MyForm()
            {
                // Your code...
       
                InitializeComponent();
    
                Application.AddMessageFilter(this);
            }
    
            public Boolean PreFilterMessage(ref Message m)
            {
                Boolean activated = (m.Msg == 0x010) || (m.Msg == 0x0A0) || (m.Msg == 0x100) || (m.Msg == 0x101) || (m.Msg == 0x200);
    
                if (activated)
                    // Your timer logics...
          
                return false;
            }
        }
    }
