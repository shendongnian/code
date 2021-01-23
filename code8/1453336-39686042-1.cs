    // Form1.OnLoad 
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        
        var root = new FolderFileNode(_path);
        treeView1.Nodes.Add(root);
        root.LoadNodes();
        treeView1.BeforeSelect += (sender, args) =>
        {              
            //This flickers a lot , a bit less between BeginUpdate/EndUpdate
            (args.Node as FolderFileNode)?.LoadNodes();                
        };
        treeView1.AfterExpand += (sender, args) =>
        {                
            (args.Node as FolderFileNode)?.SetIcon();                
        };
        treeView1.AfterCollapse += (sender, args) =>
        {
            (args.Node as FolderFileNode)?.SetIcon();                
        };
    }                    
    class FolderFileNode : TreeNode
    {
        private readonly string _path;
        private readonly bool _isFile;
        public FolderFileNode(string path)
        {            
            if(string.IsNullOrWhiteSpace(path)) throw new ArgumentException(nameof(path));
            Text = Path.GetFileName(path);
            _isFile = File.Exists(path);
            _path = path;
            if (!_isFile && Directory.EnumerateFileSystemEntries(_path).Any())
            {
                // you have set , added to the form an Imagelist for Node state 
                // in the designer or designer file set treeView1.StateImageList = imageList2
                // where imageList2 has al least 1 image
                StateImageIndex = 1;
            }
            SetIcon();
        }
        public void SetIcon()
        {
            // image[2] is Folder Open image
            ImageIndex = _isFile ? ImageIndex = 1 :  IsExpanded ? 2 : 0;
            SelectedImageIndex = _isFile ? ImageIndex = 1 :  IsExpanded ? 2 : 0;
        }
        private IEnumerable<string> _children;
        public void LoadNodes()
        {
            if (!_isFile && _children == null)
            {
               // _children = Directory.EnumerateFileSystemEntries(_path);
               // Or Add Directories first
               _children = Directory.EnumerateDirectories(_path).ToList();
                ((List<string>) _children).AddRange(Directory.EnumerateFiles(_path)); 
                Nodes.AddRange(
                    _children.Select(x => 
                        // co-variant
                        (TreeNode) new FolderFileNode(x))
                        .ToArray());
            }
        }
    }
