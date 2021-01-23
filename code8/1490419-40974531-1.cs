        // The property used for binding the ItemsSource of the sfTreeView
        private ObservableCollection<SyntaxTreeNode> _TreeViewNodes;
        public ObservableCollection<SyntaxTreeNode> TreeViewNodes
        {
            get { return _TreeViewNodes; }
            set
            {
                _TreeViewNodes = value;
            }
        }
