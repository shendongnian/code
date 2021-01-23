    public const int TVIF_STATE = 0x8;
        public const int TVIS_STATEIMAGEMASK = 0xF000;
        public const int TV_FIRST = 0x1100;
        public const int TVM_SETITEM = TV_FIRST + 63;
    
        public struct TVITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            [MarshalAs(UnmanagedType.LPTStr)]
            public String lpszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }
    
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    
    
        private void RemoveCheckBoxes(TreeView tree)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (TreeNode n in tree.Nodes)
            {
                if(n.Nodes.Count > 0)
                {
                     nodes.AddRange(GetNodes(n));
                }
            }
    
            foreach (TreeNode n in nodes)
            {
                TVITEM tvi = new TVITEM();
                tvi.hItem = n.Handle;
                tvi.mask = TVIF_STATE;
                tvi.stateMask = TVIS_STATEIMAGEMASK;
                tvi.state = 0;
                IntPtr lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvi));
                Marshal.StructureToPtr(tvi, lparam, false);
                SendMessage(this.treeView1.Handle, TVM_SETITEM, IntPtr.Zero, lparam);
            }
        }
    
        private List<TreeNode> GetNodes(TreeNode node)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            if(node.Nodes.Count > 0)
                nodes.Add(node);
            foreach (TreeNode n in node.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    nodes.AddRange(GetNodes(n));
                }
            }
            return nodes;
        }
    
