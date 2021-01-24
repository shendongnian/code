    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MyCollection Collection { get; }
    
            public MainWindow()
            {
                InitializeComponent();
    
                Collection = new MyCollection();
    
                DataContext = Collection;
            }
    
            private void button_Click(object sender, RoutedEventArgs e)
            {
                Collection.Add(Collection.Count);
            }
        }
        
        public sealed class MyCollection : ObservableCollection<int>
        {
            public MyCollection()
            {
                CollectionChanged += MyCollection_CollectionChanged;
            }
    
            private void MyCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(TopItems)));
            }
    
            public IEnumerable<int> TopItems => this.Take(3);
        }
    }
