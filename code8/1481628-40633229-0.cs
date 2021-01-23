    using System.Linq;
    using System.Windows.Forms;
    using System.ComponentModel;
    public class MyTabControl : TabControl
    {
        public MyTabControl()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                SetStyle(ControlStyles.UserMouse, true);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var filteredKeys = new Keys[]{(Keys.Control | Keys.Tab),
                (Keys.Control | Keys.Shift | Keys.Tab),
                Keys.Left, Keys.Right, Keys.Home, Keys.End};
            if (filteredKeys.Contains(keyData))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
