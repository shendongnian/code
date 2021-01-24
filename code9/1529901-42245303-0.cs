    public class MaxValueEntry : Behavior<Entry>
    {
        public int Max { get; set; }
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if(args.NewTextValue.Length > Max)
                ((Entry)sender).TextColor = Color.Red;
            else
                ((Entry)sender).TextColor = Color.Default;
        }
    }
