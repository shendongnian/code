    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace MyProject
    {
        public partial class Form2 : Form
        {
            public Form2(Form formToCover)
            {
                InitializeComponent();
                this.AllowTransparency = true;
                this.TransparencyKey = Color.White;
                this.BackColor = Color.White;
                this.FormBorderStyle = FormBorderStyle.None;
                this.ControlBox = false;
                this.ShowInTaskbar = false;
                this.StartPosition = FormStartPosition.Manual;
                this.AutoScaleMode = AutoScaleMode.None;
                this.Location = formToCover.PointToScreen(Point.Empty);
                this.ClientSize = formToCover.ClientSize;
                formToCover.LocationChanged += Cover_LocationChanged;
                formToCover.ClientSizeChanged += Cover_ClientSizeChanged;
                // Show and focus the form
                this.Show(formToCover);
                formToCover.Focus();
                // Disable Aero transitions, the plexiglass gets too visible
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    int value = 1;
                    DwmSetWindowAttribute(formToCover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
                }
            }
            private void Cover_LocationChanged(object sender, EventArgs e)
            {
                // Ensure the plexiglass follows the owner
                this.Location = this.Owner.PointToScreen(Point.Empty);
            }
            private void Cover_ClientSizeChanged(object sender, EventArgs e)
            {
                // Ensure the plexiglass keeps the owner covered
                this.ClientSize = this.Owner.ClientSize;
            }
            protected override void OnFormClosing(FormClosingEventArgs e)
            {
                // Restore owner
                this.Owner.LocationChanged -= Cover_LocationChanged;
                this.Owner.ClientSizeChanged -= Cover_ClientSizeChanged;
                if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
                {
                    int value = 1;
                    DwmSetWindowAttribute(this.Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
                }
                base.OnFormClosing(e);
            }
            protected override void OnActivated(EventArgs e)
            {
                // Always keep the owner activated instead
                this.BeginInvoke(new Action(() => this.Owner.Activate()));
            }
            
            private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
            [DllImport("dwmapi.dll")]
            private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int value, int attrLen);
        }
    }
