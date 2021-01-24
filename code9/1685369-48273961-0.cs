        public class MyRadioGroup:RadioGroup
        {
            //Every native control in xaml will be wrapped in NativeViewWrapper, so we want to pass a NativeViewWrapper list here
            IList<NativeViewWrapper> items;
            public IList<NativeViewWrapper> ItemsSource
            {
                get {
                    items.Clear();
                    for (int i = 0; i < this.ChildCount; i++)
                    {
                        items.Add(new NativeViewWrapper(this.GetChildAt(i)));
                    }
                    return items;
                }
                set {
                    //xaml compiler will call this setter
                    if (items != value)
                    {
                        items = value;
                        this.RemoveAllViews();
                        foreach (NativeViewWrapper wrapper in items)
                        {
                            this.AddView(wrapper.NativeView);
                        }
                    }
                }
            }
            public MyRadioGroup(Context context) : base(context)
            {
                items = new List<NativeViewWrapper>();
            }
        }
