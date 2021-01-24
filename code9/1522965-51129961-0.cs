    class MyEditor : UITypeEditor {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            var type = Type.GetType(@"System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
            var editor = Activator.CreateInstance(type, new[] { typeof(UITypeEditor) });
            var result = ((UITypeEditor)editor).EditValue(context, provider, value);
            // call your event here
            return result;
        }
    }
