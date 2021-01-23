    public class CommentsBehavior : Behavior
    {
        public ObservableCollection<string> Comments ... // you will need to make it a dependency property
        protected virtual void OnAttached()
        {
            Comments.CollectionChanged += OnCollectionChanged;
        }
        protected virtual void OnDetaching()
        {
            Comments.CollectionChanged -= OnCollectionChanged;
        }
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach(string newItem in e.NewItems)
                {
                    ((TextBox)AssociatedObject).Text = ((TextBox)AssociatedObject).Text + '\n' + newItem;   
                }
            }
        }
    }
