    public class WListView : ListView
    {
        #region [ PInvoke ]
        private const int LVM_HITTEST = 0x1000 + 18;
        private const int LVM_SUBITEMHITTEST = 0x1000 + 57;
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
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref LVHITTESTINFO ht);
        #endregion
        /// <summary>
        /// Occurs when a group is clicked.
        /// </summary>
        [Category("Behavior")]
        [Description("Occurs when a group header is clicked.")]
        public event EventHandler<ListViewGroupClickEventArgs> GroupClick;
        /// <summary>
        /// Raises the GroupClick event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected virtual void OnGroupHeaderClick(ListViewGroupClickEventArgs e)
        {
            GroupClick?.Invoke(this, e);
        }
        /// <summary>
        /// Raises the Control.MouseDoubleClick event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            var group = TestGroupHit(e);
            if (group == null)
            {
                return;
            }
            switch (e.Clicks)
            {
                case 1:
                    OnGroupHeaderClick(new ListViewGroupClickEventArgs(group));
                    break;
            }
        }
        private ListViewGroup TestGroupHit(MouseEventArgs e)
        {
            var ht = new LVHITTESTINFO { pt_x = e.X, pt_y = e.Y };
            var msg = View == System.Windows.Forms.View.Details ? LVM_SUBITEMHITTEST : LVM_HITTEST;
            var value = SendMessage(Handle, msg, -1, ref ht);
            if (value != -1 && (ht.flags & LVHT_EX_GROUP_HEADER) != 0)
            {
                return FindGroupByID(value);
            }
            return null;
        }
        private ListViewGroup FindGroupByID(int id)
        {
            foreach (ListViewGroup group in Groups)
            {
                if (group.ExtractID() == id)
                {
                    return group;
                }
            }
            return null;
        }
    }
