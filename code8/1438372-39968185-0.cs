    using System;
    using System.Drawing.Design;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    // ...
    
    [Editor(typeof(SomeProperty_Editor), typeof(UITypeEditor))] // You might be able to place this attribute on class SomeType, but I haven't tried yet
    public SomeType SomeProperty
    {
    	get { /* stuff */ }
    	set { /* stuff */ } // optional, really
    }
    
    class SomeProperty_Editor : UITypeEditor
    {
    	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
    	{
    		return UITypeEditorEditStyle.Modal;
    	}
    
    	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
    	{
    		IWindowsFormsEditorService service = (IWindowsFormsEditorService)(provider.GetService(typeof(IWindowsFormsEditorService)));
    		SomeProperty_EditorWindow EditorWindow = new SomeProperty_EditorWindow(value as SomeType);
    		service.ShowDialog(EditorWindow);
    		if (EditorWindow.EditCancelled)
    			return value;
    		else
    			return EditorWindow.GetEdittedValue();
    	}
    }
    
    class SomeProperty_EditorWindow : Form
    {
    	public SomeProperty_EditorWindow(SomeType CurrentProperty) : base()
    	{
    		InitializeComponents();
    		
    		// Grab info in CurrentProperty here and display it on form
    	}
    	
    	public void InitializeComponents()
    	{
    		// write yourself or use designer
    	}
    	
    	public SomeType GetEdittedValue()
    	{
    		// return editted value from form components 
    	}
    	
    	public bool EditCancelled = false; // Set true if cancel button hit
    }
