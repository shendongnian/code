    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    namespace WpfApp2
    {
        public class Directory : FileSystemElement, IEnumerable<IFileSystemElement>
        {
            public Directory(string name) : base(name)
            {
            }
    
            public ICollection<IFileSystemElement> Elements { get; } = new ObservableCollection<IFileSystemElement>();
    
            public IEnumerator<IFileSystemElement> GetEnumerator()
            {
                return Elements.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable) Elements).GetEnumerator();
            }
    
            public T Add<T>(T item) where T : IFileSystemElement
            {
                Elements.Add(item);
                return item;
            }
        }
    }
