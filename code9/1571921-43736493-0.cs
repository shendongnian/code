     public class MyCollectionEditor : CollectionEditor
        {
            public MyCollectionEditor()
                : base(typeof(MyCollection))
            {
            }
    
            protected override CollectionForm CreateCollectionForm()
            {
                CollectionForm form = base.CreateCollectionForm();
                Type type = form.GetType();
                PropertyInfo propertyInfo = type.GetProperty("CollectionEditable", BindingFlags.Instance | BindingFlags.NonPublic);
                propertyInfo.SetValue(form, true);
                return form;
            }
    
            protected override Type CreateCollectionItemType()
            {
                return typeof(MyCollection);
            }
    
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                return base.EditValue(context, provider, value);
            }
        }
