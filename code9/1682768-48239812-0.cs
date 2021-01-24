    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace ThreadSafeControls
    {
        class TextBoxBackgroundThread : System.Windows.Forms.TextBox
        {
            public override string Text
            {
                get
                {
                    return base.Text;
                }
    
                set
                {
                    if (this.InvokeRequired)
                        this.Invoke((MethodInvoker)delegate { base.Text = value; });
                    else
                        base.Text = value;
                }
            }
    
            public override System.Drawing.Color ForeColor
            {
                get
                {
                    return base.ForeColor;
                }
    
                set
                {
                    if (this.InvokeRequired)
                        this.Invoke((MethodInvoker)delegate { base.ForeColor = value; });
                    else
                        base.ForeColor = value;
                }
            }
    
    
            public override System.Drawing.Color BackColor
            {
                get
                {
                    return base.BackColor;
                }
    
                set
                {
                    if (this.InvokeRequired)
                        this.Invoke((MethodInvoker)delegate { base.BackColor = value; });
                    else
                        base.BackColor = value;
                }
            }
        }
    
        class ButtonBackgroundThread : System.Windows.Forms.Button
        {
            public override string Text
            {
                get
                {
                    return base.Text;
                }
    
                set
                {
                    if (this.InvokeRequired)
                        this.Invoke((MethodInvoker)delegate { base.Text = value; });
                    else
                        base.Text = value;
                }
            }
    
            public override System.Drawing.Color ForeColor
            {
                get
                {
                    return base.ForeColor;
                }
    
                set
                {
                    if (this.InvokeRequired)
                        this.Invoke((MethodInvoker)delegate { base.ForeColor = value; });
                    else
                        base.ForeColor = value;
                }
            }
    
    
            public override System.Drawing.Color BackColor
            {
                get
                {
                    return base.BackColor;
                }
    
                set
                {
                    if (this.InvokeRequired)
                        this.Invoke((MethodInvoker)delegate { base.BackColor = value; });
                    else
                        base.BackColor = value;
                }
            }
        }
    }
