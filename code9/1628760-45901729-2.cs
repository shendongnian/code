    //using System.Runtime.InteropServices;
    //using System.Diagnostics;
    [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
    public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
    private void button1_Click(object sender, EventArgs e)
    {
        var notepad = Process.GetProcessesByName("notepad").FirstOrDefault();
        if(notepad!=null)
        {
            var owner = notepad.MainWindowHandle;
            var owned = this.Handle;
            var i = SetWindowLong(owned, -8 /*GWL_HWNDPARENT*/, owner);
        }
    }
