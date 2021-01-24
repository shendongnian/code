        public PXSelect<TreeNode> Nodes;
        public PXSelect<TreeNode,
                   Where<TreeNode.parentNodeID,
                       Equal<Optional<TreeNode.nodeID>>>> ChildNodes;
        public PXSelect<TreeNode, 
                    Where<TreeNode.nodeID, 
                        Equal<Current<TreeNode.nodeID>>>> CurrentNode;
        #endregion
        #region Delegates
        protected virtual IEnumerable nodes(
            [PXInt]
            int? nodeID
        )
        {
            if (nodeID == null)
            {
                yield return new TreeNode()
                {
                    ParentNodeID = 0,
                    NodeID = 0
                };
            }
            else
            {
                foreach (TreeNode node in ChildNodes.Select(nodeID))
                {
                    yield return node;
                }
            }
        }
        protected virtual IEnumerable currentNode()
        {
            if (Nodes.Current != null)
            {
                var isNotRoot = Nodes.Current.NodeID != 0;
                //Situation where we would want to limit the recursion to one 
                AddNode.SetEnabled(!isNotRoot);
                DeleteNode.SetEnabled(isNotRoot);
                
                Caches[typeof(TreeNode)].AllowInsert = isNotRoot;
                Caches[typeof(TreeNode)].AllowDelete = isNotRoot;
                Caches[typeof(TreeNode)].AllowUpdate = isNotRoot;
                foreach (TreeNode item in PXSelect<TreeNode,
                                                        Where<TreeNode.nodeID, 
                                                            Equal<Required<TreeNode.nodeID>>>>.
                                                    Select(this, Nodes.Current.NodeID))
                {
                    yield return item;
                }
            }
        }
        public PXAction<NodeSetup> AddNode;
        [PXUIField(DisplayName = " ", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select, Enabled = true)]
        [PXButton()]
        public virtual IEnumerable addNode(PXAdapter adapter)
        {
            var selectedNode = Nodes.Current;
            if (selectedNode.ParentNodeID == 0)
            {
                var inserted = (TreeNode)Caches[typeof(TreeNode)].Insert(new TreeNode
                {
                    ParentNodeID = Nodes.Current.NodeID
                });
                inserted.TempChildID = inserted.NodeID;
                inserted.TempParentID = inserted.ParentNodeID;
                Nodes.Cache.ActiveRow = inserted;
            }
            return adapter.Get();
        }
        public PXAction<NodeSetup> DeleteNode;
        [PXUIField(DisplayName = " ", MapEnableRights = PXCacheRights.Select, MapViewRights = PXCacheRights.Select, Enabled = true)]
        [PXButton()]
        public virtual IEnumerable deleteNode(PXAdapter adapter)
        {
            var selectedNode = Nodes.Current;
            if(selectedNode.NodeID != 0)
            {
                if(selectedNode.ParentNodeID == 0)
                {
                    var childrenNodes = ChildNodes
                                         .Select(selectedNode.NodeID)
                                         .Select(br => (TreeNode)br).ToList();
                    if (childrenNodes.Any())
                    {
                        if (Document.Ask(Messages.ValidationDeleteChildren, MessageButtons.YesNo) == WebDialogResult.Yes)
                        {
                            foreach(var childrenNode in childrenNodes)
                            {
                                Caches[typeof(TreeNode)].Delete(childrenNode);
                            }
                            Caches[typeof(TreeNode)].Delete(selectedNode);
                        }
                    }
                    else
                    {
                        Caches[typeof(TreeNode)].Delete(selectedNode);
                    }
                }
                else
                {
                    Caches[typeof(TreeNode)].Delete(selectedNode);
                }
            }
            return adapter.Get();
        }
