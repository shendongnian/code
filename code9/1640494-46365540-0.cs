	public partial class MyGroupingHeaderCell : ViewCell
	{
        public static readonly BindableProperty CollectionProperty =
            BindableProperty.Create(
                "Collection", typeof(INotifyCollectionChanged), typeof(MyGroupingHeaderCell),
                defaultValue: default(INotifyCollectionChanged), propertyChanged: OnCollectionChanged);
        public INotifyCollectionChanged Collection
        {
            get { return (INotifyCollectionChanged)GetValue(CollectionProperty); }
            set { SetValue(CollectionProperty, value); }
        }
        private static void OnCollectionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((MyGroupingHeaderCell)bindable).OnCollectionChangedImpl((INotifyCollectionChanged)oldValue, (INotifyCollectionChanged)newValue);
        }
        protected virtual void OnCollectionChangedImpl(INotifyCollectionChanged oldValue, INotifyCollectionChanged newValue)
        {
            if(oldValue != null)
                oldValue.CollectionChanged -= OnCollectionChanged;
            if(newValue != null)
                newValue.CollectionChanged += OnCollectionChanged;
            OnCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
		void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
            var item = BindingContext as ObservableGroupCollection<string, CustomObject>;
            if (item != null)
            {
                this.keyName.Text = item.Key + " (" + item.Count + ")";
            }
            else
            {
                this.keyName.Text = string.Empty;
            }
		}
	}
