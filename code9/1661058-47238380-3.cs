    public override object EditValue(ITypeDescriptorContext context,
        IServiceProvider provider, object value)
    {
        var svc = provider.GetService(typeof(IWindowsFormsEditorService))
            as IWindowsFormsEditorService;
        var myGenericTypeProperty = context.Instance.GetType()
            .GetProperty("MyGenericType");
        var genericArgument = (Type)myGenericTypeProperty.GetValue(context.Instance);
        var editorFormType = typeof(MyEditorForm<>);
        var genericArguments = new[] { genericArgument };
        var editorFormInstance = editorFormType.MakeGenericType(genericArguments);
        if (svc != null) {
            using (var f = (Form)Activator.CreateInstance(editorFormInstance)) {
                f.GetType().GetProperty("List").SetValue(f, value);
                if (svc.ShowDialog(f) == DialogResult.OK)
                    return ((dynamic)f).List;
            }
        }
        else {
            using (var f = (Form)Activator.CreateInstance(editorFormInstance)) {
                f.GetType().GetProperty("List").SetValue(f, value);
                if (f.ShowDialog() == DialogResult.OK)
                    return ((dynamic)f).List;
            }
        }
        return base.EditValue(context, provider, value);
    }
