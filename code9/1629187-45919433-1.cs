    public class FilterFom
    {
        public int a { get; set; }
    
    	public filter(string FieldName, string Values)     
    	{
    		s1 = FieldName;
    		s2 = Values;
    		a = 10; //Here I can assign value to public property of this class.
    	}
    
    	private void OnSubmitClick(object sender, EventArgs e)
    	{
    		this.DialogResult = DialogResult.OK;
    		this.Close();
    	}
    }
