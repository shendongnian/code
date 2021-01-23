    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace SOF
    {
        public class BaseForm : Form
        {
            public BaseForm()
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Size = new Size(400, 400);
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                this.MaximizeBox = false;
            }
        }
    }
