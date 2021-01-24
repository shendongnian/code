    public partial class TabBar : UserControl
    {
        ....
        // Using a DependencyProperty as the backing store for SelectionIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectionIndexProperty =
            DependencyProperty.Register("SelectionIndex", typeof(int), typeof(TabBar), new PropertyMetadata(0, propertyChangedCallback: (d,e)=> ((TabBar)d).OnSelectionIndexChanged()));
        public void OnSelectionIndexChanged()
        {
            switch (SelectionIndex)
            {
                // ....
            }
        }
    }
