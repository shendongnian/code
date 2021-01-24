    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class MyRichTextBox : RichTextBox
    {
        private const UInt32 WM_PAINT = 0x000F;
        private const UInt32 WM_USER = 0x0400;
        private const UInt32 EM_SETBKGNDCOLOR = (WM_USER + 67);
        private const UInt32 WM_KILLFOCUS = 0x0008;
    
        public MyRichTextBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }
    
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
    
            Graphics g = Graphics.FromHwnd(Handle);
            Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);
            Pen p = new Pen(SystemColors.Highlight, 3);
    
            if (m.Msg == WM_PAINT)
            {
                if (this.Enabled == true)
                {
    
                    if (this.Focused)
                    {
                        g.DrawRectangle(p, bounds);
                    }
    
                    else
                    {
                        g.DrawRectangle(SystemPens.ControlDark, bounds);
                    }
    
                }
                else
                {
                    g.FillRectangle(Brushes.White, bounds);
                    g.DrawRectangle(SystemPens.Control, bounds);
                }
            }
    
            if (m.Msg == EM_SETBKGNDCOLOR) //color disabled background
            {
                Invalidate();
            }
    
            if (m.Msg == WM_KILLFOCUS) //set border back to normal on lost focus
            {
                Invalidate();
            }
        }
    
    }
