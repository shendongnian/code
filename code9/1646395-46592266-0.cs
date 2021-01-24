    List<Control> pageControls = new List<Control>();
    List<Control> elementControls = new List<Control>();
    protected void createFormButton_Click(object sender, EventArgs e)
        {
    
           ////titles is the div id of where i want to insert the title label
            var titlelabel = new Label();
            titlelabel.Text = textboxForTitle.Text;
            titles.Controls.Add(titlelabel);
            pageControls.Add(titlelabel);
    
            if (optionsDropdown.SelectedValue == "Checkbox")
            {
               //elements is the div id of where i want to insert the control
                var newControl = new CheckBox();
                newControl.CssClass = "checkbox";
                newControl.Checked = true;
                elements.Controls.Add(newControl);
                pageControls.Add(newControl);
            }
    
            else if (optionsDropdown.SelectedValue == "Textbox")
            {
               //elements is the div id of where i want to insert the control
                var newControl = new TextBox();
                newControl.Text = "this is some text on the new box";
                newControl.CssClass = "form-control";
                elementControls.Add(newControl);
            }
    
            else if (optionsDropdown.SelectedValue == "Dropdown")
            {
               //elements is the div id of where i want to insert the control
                var newControl = new DropDownList();
                newControl.Items.Add("one");
                newControl.Items.Add("two");
                newControl.Items.Add("three");
                newControl.CssClass = "form-control";
                elementControls.Add(newControl);
            }
            Controls.AddRange(pageControls);
            elements.Controls.AddRange(elementControls);
        }
