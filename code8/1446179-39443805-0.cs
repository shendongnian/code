    const int LENGTH_MIN_NAME = 2;
    private void Name_TextChanged(object sender, EventArgs e)
    {
    	this.ConvertBtn.Enabled = isValid(Name.Text.Trim());
    }
    
    public bool isValid(String text)
    {
    	return (!(string.IsNullOrWhiteSpace(text) ||  text.Length <= LENGTH_MIN_NAME));
    }
