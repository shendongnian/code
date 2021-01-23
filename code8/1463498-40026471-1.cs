    namespace Sample
    {
        public class ListView : System.Windows.Controls.ListView
        {
            protected override DependencyObject GetContainerForItemOverride()
            {
                return new ListViewItem();
            }
        }
    }
