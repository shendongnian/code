    public class ObservableCollectionWithDeletionControl<T> : ObservableCollection<T>
    {
        public delegate void DeletionDeniedEventHandler(object sender, int indexOfDeniedDeletion);
        public event DeletionDeniedEventHandler DeletionDenied;
        public bool CanDelete { get; set; }
        protected virtual void OnDeletionDenied(int indexOfDeniedDeletion)
        {
            if (DeletionDenied != null) { DeletionDenied(this, indexOfDeniedDeletion); }
        }
        protected override void RemoveItem(int index)
        {
            if (CanDelete)
            {
                base.RemoveItem(index);
            }
            else
            {
                OnDeletionDenied(index);
            }
        }
    }
