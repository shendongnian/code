    public List<TextBox> textbox_generator(int days_count)
    {
        var textBoxes = new List<TextBox>();
    
        for(int i = 0; i < days_count; i++)
        {
            txt_desc = new TextBox();
            txt_desc.ID = "txt_desc" + i.ToString();
            txt_desc.CssClass = "form-control";
            txt_desc.Attributes.Add("placeholder", "Enter day " + i + " description");
            txt_desc.TextMode = TextBoxMode.MultiLine;
            textBoxes.Add(txt_desc);          
        }
    
        return textBoxes;
    }
