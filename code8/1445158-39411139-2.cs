    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
<!---->
    public class MyMaskedTextBox : MaskedTextBox
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_NCPAINT)
            {
                var hdc = NativeMethods.GetWindowDC(this.Handle);
                using (var g = Graphics.FromHdcInternal(hdc))
                {
                    var a = AbsoluteClientRECT;
                    g.FillRectangle(Brushes.White, 0, 0, Width, a.Top);
                    g.FillRectangle(Brushes.White, 0, 0, a.Left, Height);
                    g.FillRectangle(Brushes.White, 0, a.Bottom, Width, Height - a.Height);
                    g.FillRectangle(Brushes.White, a.Right, 0, Width - a.Right, Height);
                    g.DrawRectangle(Pens.Blue, new Rectangle(0, 0, Width - 1, Height - 1));
                }
                NativeMethods.ReleaseDC(this.Handle, hdc);
                m.Result = IntPtr.Zero;
            }
            else
                base.WndProc(ref m);
        }
        private Rectangle AbsoluteClientRECT
        {
            get
            {
                NativeMethods.RECT rect = new NativeMethods.RECT();
                CreateParams cp = this.CreateParams;
                NativeMethods.AdjustWindowRectEx(ref rect, cp.Style, false, cp.ExStyle);
                int left = -rect.left; int top = -rect.top;
                NativeMethods.GetClientRect(this.Handle, ref rect);
                rect.left += left; rect.right += left; rect.top += top; rect.bottom += top;
                return Rectangle.FromLTRB(rect.left, rect.top, rect.right, rect.bottom);
            }
        }
    }
