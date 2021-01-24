    public class AutofillTextView : Entry
    {
        public static BindableProperty ChoicesSourceProperty = BindableProperty.Create(
                nameof(ChoicesSource), typeof(ObservableCollection<string>), typeof(CustomPicker), 
                default(ObservableCollection<string>), propertyChanged: OnChoicesSourceChanged);
        public ObservableCollection<string> ChoicesSource
        {
            get { return (ObservableCollection<string>)GetValue(ChoicesSourceProperty); }
            set { SetValue(ChoicesSourceProperty, value); }
        }
        public AutofillTextView()
        {
            Items = new List<string>();
        }
        private void ChoicesChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Items.Add(args.NewItems[0]);
                    break;
                default:
                    var itemsList = ChoicesSource.ToList();
                    Items = itemsList;
                    break;
            }
            OnPropertyChanged(nameof(Items));
        }
        private static void OnChoicesSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var textView = (AutofillTextView) bindable;
            textView.ChoicesSource.CollectionChanged -= textView.ChoicesChanged;
            textView.ChoicesSource.CollectionChanged += textView.ChoicesChanged;
            textView.Items = newValue == null ? new List<string>() : ((ObservableCollection<string>)newValue).ToList();
        }
    }
