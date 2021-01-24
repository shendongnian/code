    public void textbox_generator(int days_count, Panel panel)
    {
        for(int i = 0; i < days_count; i++)
        {
            txt_desc = new TextBox();
            txt_desc.ID = "txt_desc" + i.ToString();
            txt_desc.CssClass = "form-control";
            txt_desc.Attributes.Add("placeholder", "Enter day " + i + " description");
            txt_desc.TextMode = TextBoxMode.MultiLine;
            panel.Controls.Add(txt_desc);          
        }
    }
