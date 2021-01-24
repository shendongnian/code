    public class EditorHeaterPID : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => UITypeEditorEditStyle.Modal;
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            SomeForm form = new SomeForm(value);
            if (form.ShowDialog() == DialogResult.OK)
                return form.Items;
            return value;
        }
    }
