		public class MyFileNameEditor : System.Windows.Forms.Design.FileNameEditor
        {
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                var fullname = base.EditValue(context, provider, value);
                
                if (!string.IsNullOrEmpty(fullname)){
                    /// modify Fullname here to return relative path
                }
                return fullname;
            }
        }
