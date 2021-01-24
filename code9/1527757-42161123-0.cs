    void Main()
    {
	var cb1 = new ComboBox()
    var cb2 = new ComboBox()
	var frm = new Form()
	
	var selectedItemAndValue = new List<selectedItem>();
	
	foreach (Control ctrl in frm.Controls)
	{
		if (ctrl.GetType() == typeof(ComboBox)
		{
			var cb = ctrl as ComboBox
            selectedItemAndValue.Add(new selectedItem {
			Idx = cb.SelectedIndex, 
			Text = cb.SelectedText, 
			Value = cb.SelectedValue.ToString()})
			
		}
		
		//the above code will then give you a list of everything that is selected in each of your combo boxes
	}
    }
    public class selectedItem
    {
	public int Idx { get; set; }
	public string Text { get; set; }
	public string Value {get; set;}
    }
    // Define other methods and classes here
