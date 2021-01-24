    [Browsable(true)]
    [Editor(typeof(TestDesignProperty), typeof(UITypeEditor))]
    [DefaultValue(null)]
    public string SelectedObject { get; set; }
    public class TestDesignProperty : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            
            var edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            ListBox lb = new ListBox();
            var form1 = (Form1) Activator.CreateInstance(typeof (Form1)); //Change with your form class
            foreach (Control control in form1.Controls)
            {
                lb.Items.Add(control.Name);
            }
          
            if (value != null)
            {
                lb.SelectedItem = value;
            }
            edSvc.DropDownControl(lb);
            value = (string)lb.SelectedItem;
            return value;
        }
    }
