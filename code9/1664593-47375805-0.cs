    // decorate the property with this custom attribute  
    [Editor(typeof(StringListEditor), typeof(UITypeEditor))]
    public List<String> keepLabels { get; set; }
    ....
    // this is the code of a custom editor class
    // note CollectionEditor needs a reference to System.Design.dll
    public class StringListEditor : CollectionEditor
    {
        public StringListEditor(Type type)
            : base(type)
        {
        }
 
        // you can override the create instance and return whatever you like
        protected override object CreateInstance(Type itemType)
        {
            if (itemType == typeof(string))
                return string.Empty; // or anything else
            return base.CreateInstance(itemType);
        }
    }
