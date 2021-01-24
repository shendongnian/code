    public class MyUITypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, 
            IServiceProvider provider, object value)
        {
            var svc = provider.GetService(typeof(IWindowsFormsEditorService)) 
                as IWindowsFormsEditorService;
            var componentProperty = context.GetType().GetProperty("Component");
            var container = componentProperty.GetValue(context);
            var myGenericTypeProperty = container.GetType().GetProperty("MyGenericType");
            var genericArgument = (Type)myGenericTypeProperty.GetValue(container);
            var editorFormType = typeof(MyEditorForm<>);
            var genericArguments = new[] { genericArgument };
            var editorFormInstance = editorFormType.MakeGenericType(genericArguments);
            if (svc != null)
            {
                using (var f = (Form)Activator.CreateInstance(editorFormInstance))
                    if (svc.ShowDialog(f) == DialogResult.OK)
                        return ((dynamic)f).SelectedProperty;
            }
            else
            {
                using (var f = (Form)Activator.CreateInstance(editorFormInstance))
                    if (f.ShowDialog() == DialogResult.OK)
                        return ((dynamic)f).SelectedProperty;
            }
            return base.EditValue(context, provider, value);
        }
    }
