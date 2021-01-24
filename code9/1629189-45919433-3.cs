    public class FilterFom
    {
        public TextBox a { get; private set; }
    
    	public filter(string FieldName, string Values)     
    	{
    		s1 = FieldName;
    		s2 = Values;
    		a = new TextBox(); //Here I can assign value to public property of this class.
    	}
    
    	private void OnSubmitClick(object sender, EventArgs e)
    	{
    		this.DialogResult = DialogResult.OK;
    		this.Close();
    	}
    }
