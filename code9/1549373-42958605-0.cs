    public MyForm()
            {
                InitializeComponent();
    
                //LoadTree();
                SetupColoumn();
                LoadTree1();
            }
    
            private void SetupColoumn()
            {
                // Get the size of the file system entity. 
                // Folders and errors are represented as negative numbers
                this.olvColumn1.AspectGetter = delegate(object x)
                {
                    return ((XmlNode)(x)).Attributes["name"].Value;
                };
            }
            private void LoadTree1()
            {
                XmlDocument reader = new XmlDocument();
                reader.Load(@"F:\Test1.xml");
                ArrayList roots = new ArrayList();
                String xpath = "/TestSuite/TestCase";
                var nodes = reader.SelectNodes(xpath);
    
                foreach (XmlNode childrenNode in nodes)
                {
                    roots.Add(childrenNode);
                    //roots.Add(childrenNode.Attributes["Name"].Value);
                }
    
                this.treeListView1.CanExpandGetter = delegate(object x)
                {
                    //return ((MyFileSystemInfo)x).IsDirectory;
                    return ((XmlNode)x).HasChildNodes;
                };
    
                this.treeListView1.ChildrenGetter = delegate(object x)
                {
                    ArrayList children = new ArrayList();
                    var node1 = ((XmlNode)x).ChildNodes;
                    if (x is XmlNode)
                    {
                        //foreach (XmlNode node in roots)
                        {
                            foreach (XmlNode n in node1)
                            {
                                children.Add(n);
                            }
                        }
                    }
    
                    return children;
    
                };
    
                treeListView1.SetObjects(roots);
            }
}
