    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public class MyListView : ListView
    {
        public event EventHandler<int> GroupHeaderClick;
        protected virtual void OnGroupHeaderClick(int e)
        {
            var handler = GroupHeaderClick;
            if (handler != null) handler(this, e);
        }
        private const int LVM_HITTEST = 0x1000 + 18;
        private const int LVHT_EX_GROUP_HEADER = 0x10000000;
        [StructLayout(LayoutKind.Sequential)]
        private struct LVHITTESTINFO
        {
            public int pt_x;
            public int pt_y;
            public int flags;
            public int iItem;
            public int iSubItem;
            public int iGroup;
        }
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg,
            int wParam, ref LVHITTESTINFO ht);
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            var ht = new LVHITTESTINFO() { pt_x = e.X, pt_y = e.Y };
            var value = SendMessage(this.Handle, LVM_HITTEST, -1, ref ht);
            if (value != -1 && (ht.flags & LVHT_EX_GROUP_HEADER) != 0)
                OnGroupHeaderClick(value);
        }
    }
