    BindingList<YourModel> someProperty = new BindingList<YourModel>();
    [Editor(typeof(MyUITypeEditor), typeof(UITypeEditor))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [TypeConverter(typeof(CollectionConverter))]
    public BindingList<YourModel> SomeProperty
    {
        get { return someProperty; }
        set { someProperty = value; }
    }
