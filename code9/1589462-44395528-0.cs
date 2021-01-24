    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace MyApp
    {
        public class PanelEx : System.Windows.Forms.Panel
        {
            public PanelEx()
            {
                this.SetStyle(
                    System.Windows.Forms.ControlStyles.UserPaint | 
                    System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | 
                    System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, 
                    true);
            }
        }
    }
