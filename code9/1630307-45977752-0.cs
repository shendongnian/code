    public class KeyChangedEventArgs : PropertyChangedEventArgs
        {
            public virtual string NewKey { get; }
            public KeyChangedEventArgs(string propertyName, string newKey) : base(propertyName)
            {
                NewKey = newKey;
            }
        }
        public delegate void KeyChangedEventHandler(object sender, KeyChangedEventArgs e);
        public interface INotifyKeyChanged
        {
            event KeyChangedEventHandler KeyChanged;
        }
        /// <summary>
        /// Interface for the mutablekey keyedcollection.
        /// </summary>
        /// <typeparam name="T"></typeparam>        
        public interface IMyKeyedCollectionItem<T> : INotifyKeyChanged where T : IMyKeyedCollectionItem<T>
        {
            /// <summary>
            /// Gets the key for the item of the collection.
            /// </summary>
            /// <returns>The item key.</returns>
            string GetKey();
        }
        public class FooItem : IMyKeyedCollectionItem<FooItem>
        {
            public FooItem(string name)
            {
                Name = name;
            }                        
            private string _name;              
            public string Name
            {
                get { return _name; }
                set
                {
                    if (!String.Equals(_name, value, StringComparison.OrdinalIgnoreCase)) // case-insensitive
                    {                        
                        // The key on the KeyedCollection must be changed before changing the key on the item.
                        OnKeyChanged(value);
                        _name = value;                        
                    }
                }
            }
            public event KeyChangedEventHandler KeyChanged;
            [NotifyPropertyChangedInvocator]
            protected virtual void OnKeyChanged(string newKey, [CallerMemberName] string propertyName = null)
            {
                KeyChanged?.Invoke(this, new KeyChangedEventArgs(propertyName, newKey));
            }
            public string GetKey()
            {
                return Name;
            }
        }
                
        // KeyedCollection is an abstract class, so I have to derive            
        public abstract class MyKeyedCollectionBase<T> : KeyedCollection<string, T> where T : IMyKeyedCollectionItem<T>
        {            
            public MyKeyedCollectionBase() : base(StringComparer.OrdinalIgnoreCase, 0) { } // case-insensitive
            public MyKeyedCollectionBase(MyKeyedCollectionBase<T> collection)
            {
                if (collection != null)
                {
                    foreach (var item in collection)
                        Add(item);
                }
            }            
            protected override void InsertItem(int index, T item)
            {
                base.InsertItem(index, item);
                SubscribeKeyChanged(item);
            }
            private void SubscribeKeyChanged(T item)
            {                
                ((INotifyKeyChanged)item).KeyChanged += OnItemKeyChanged;
            }
            private void OnItemKeyChanged(object sender, KeyChangedEventArgs e)
            {
                var item = (T) sender;
                ChangeKey(item, e.NewKey);
            }
            
            private void UnsubscribeKeyChanged(T item)
            {
                ((INotifyKeyChanged)item).KeyChanged -= OnItemKeyChanged;                
            }
            protected override void SetItem(int index, T item)
            {
                var replaced = Items[index];
                base.SetItem(index, item);
                SubscribeKeyChanged(item);
                UnsubscribeKeyChanged(replaced);
            }
            protected override void RemoveItem(int index)
            {
                var removedItem = Items[index];
                base.RemoveItem(index);
                UnsubscribeKeyChanged(removedItem);
            }
            protected override void ClearItems()
            {
                foreach (var removed in Items)
                    UnsubscribeKeyChanged(removed);
                base.ClearItems();
            }
            
            // Expose this method internally to allow mutable item keys: When the key for an item changes, this method is used to change the key in the lookup dictionary
            internal virtual void ChangeKey(T item, string newKey)
            {
                base.ChangeItemKey(item, newKey);
            }            
        }
        public class MyFooKeyedCollection : MyKeyedCollectionBase<FooItem>
        {
            protected override string GetKeyForItem(FooItem item)
            {
                return item.Name;
            }
        }
