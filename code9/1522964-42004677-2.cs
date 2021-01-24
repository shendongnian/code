    readonly List<string> _tagPages = new List<string>();
    [Editor(typeof(MyEditor), typeof(UITypeEditor))]
    public List<string> TabPages { get { return _tabPages; } }
    // reflection part 
    var type = Type.GetType(@"System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
    var editor = Activator.CreateInstance(type, new[] { typeof(UITypeEditor) });
    var method = type.GetMethod(nameof(EditValue), new[] { typeof(ITypeDescriptorContext), typeof(IServiceProvider), typeof(object) }); // if nameof is also missing then just use "EditValue" in place of it
    var result = method.Invoke(editor, new[] { context, provider, value });
