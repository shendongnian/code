    internal class ListViewSorter : IComparer
    {
        private const int HDI_FORMAT = 0x0004;
        private const int HDF_SORTUP = 0x0400;
        private const int HDF_SORTDOWN = 0x0200;
        private const int LVM_GETHEADER = 0x1000 + 31; // LVM_FIRST + 31
        private const int HDM_GETITEM = 0x1200 + 11; // HDM_FIRST + 11
        private const int HDM_SETITEM = 0x1200 + 12; // HDM_FIRST + 12
        private readonly int column;
        private readonly SortOrder sortOrder;
        public ListViewSorter(SortOrder sortOrder, int col, ListView listView)
        {
            IntPtr hColHeader = SendMessage(listView.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            HDITEM hdItem = new HDITEM();
            IntPtr colHeader = new IntPtr(col);
            hdItem.mask = HDI_FORMAT;
            SendMessageItem(hColHeader, HDM_GETITEM, colHeader, ref hdItem);
            if (sortOrder == SortOrder.Ascending)
            {
                hdItem.fmt &= ~HDF_SORTDOWN;
                hdItem.fmt |= HDF_SORTUP;
            }
            else if (sortOrder == SortOrder.Descending)
            {
                hdItem.fmt &= ~HDF_SORTUP;
                hdItem.fmt |= HDF_SORTDOWN;
            }
            else if (sortOrder == SortOrder.None)
            {
                hdItem.fmt &= ~HDF_SORTDOWN & ~HDF_SORTUP;
            }
            SendMessageItem(hColHeader, HDM_SETITEM, colHeader, ref hdItem);
            this.sortOrder = sortOrder;
            this.column = col;
        }
        protected virtual int DoCompare(ListViewItem item1, ListViewItem item2)
        {
            return sortOrder == SortOrder.Ascending ? String.Compare(item1.SubItems[column].Text, item2.SubItems[column].Text, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase)
                : String.Compare(item2.SubItems[column].Text, item1.SubItems[column].Text, CultureInfo.CurrentCulture, CompareOptions.IgnoreCase);
        }
        public int Compare(object x, object y)
        {
            ListViewItem item1 = (ListViewItem)x;
            ListViewItem item2 = (ListViewItem)y;
            return DoCompare(item1, item2);
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct HDITEM
        {
            public int mask;
            public int cxy;
            [MarshalAs(UnmanagedType.LPTStr)] public string pszText;
            public IntPtr hbm;
            public int cchTextMax;
            public int fmt;
            public int lParam;
            public int iImage;
            public int iOrder;
        };
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessageItem(IntPtr handle, int msg, IntPtr wParam, ref HDITEM lParam);
    }
