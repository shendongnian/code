    <TreeView x:Name="Tree">
        <TreeView.ItemContainerStyle>
            <Style TargetType="TreeViewItem">
                <Setter Property="IsExpanded" Value="{Binding Path=IsExpanded, Mode=TwoWay}"/>
            </Style>
        </TreeView.ItemContainerStyle>
        <TreeView.Resources>
            <HierarchicalDataTemplate DataType="{x:Type model:A}" ItemsSource="{Binding Childs}">
                <StackPanel Orientation="Horizontal" >
                    <TextBlock Text="{Binding Name}" />
                </StackPanel>
            </HierarchicalDataTemplate>
            <HierarchicalDataTemplate DataType="{x:Type model:B}" ItemsSource="{Binding Childs}">
                <StackPanel Orientation="Horizontal" >
                    <TextBlock Text="{Binding Name}" />
                </StackPanel>
            </HierarchicalDataTemplate>
        </TreeView.Resources>
    </TreeView>
<!---->
    public class A
    {
        public A()
        {
            // null is a placeholder. 
            // without any items TreeViewItem will not even show expander
            // (Expand event won't work either)
            Childs = new ObservableCollection<B>() { null };
        }
        public string Name { get; set; }
        private bool _isExpanded;
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                _isExpanded = value;
                // when node is expanded, RELOAD!
                if (_isExpanded)
                    LoadChilds();
            }
        }
        public ObservableCollection<B> Childs { get; set; }
        public void LoadChilds()
        {
            Childs.Clear();
            Childs.Add(new B() { Name = Guid.NewGuid().ToString() });
        }
    }
