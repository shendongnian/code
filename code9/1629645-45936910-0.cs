    public interface ICommon
    {
        string Name { get; set; }
        void LoadChilds(DBConnection connection);
    }
    public class A : ICommon
    {
        public class A()
        {
            Childs = new ObservableCollection<B>();
        }
        public string Name { get; set; }
        public ObservableCollection<B> Childs { get; set; }
        public void LoadChilds(DBConnection connection) //Type is unimportant
        {
            // adding childs
        }
    }
    public class B : ICommon
    {
        public class B()
        {
            Childs = new ObservableCollection<B>(); //Yes, rekursiv
        }
        public string Name { get; set; }
        public ObservableCollection<B> Childs { get; set; }
        public void LoadChilds(DBConnection connection)
        {
            // adding childs
        } 
    }
----------
    private void TreeView_Expanded(object sender, RoutedEventArgs e)
    {
        TreeViewItem tvi = e.OriginalSource as TreeViewItem;
        ICommon obj = tvi.DataContext as ICommon;
        if (obj != null)
            obj.LoadChilds(...);
    }
