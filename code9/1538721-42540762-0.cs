    public class MyObservableCollection<T> : ObservableCollection<T>
    {
        public bool CanDelete { get; set; }
        protected override void RemoveItem(int index)
        {
            if (CanDelete)
            {
                base.RemoveItem(index);
            }
            else
            {
                // tell user he can't delete
            }
        }
    }
