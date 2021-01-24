    //loop all the items in the form collection
    foreach (string key in Request.Form.Keys)
    {
        //check if the key contains a $, in which case it is probably an aspnet control
        if (key.Contains("$"))
        {
            //split the control name
            string[] keyArrar = key.Split('$');
            //get the last part in the array, which should be the ID of the control
            string controlID = keyArrar[keyArrar.Length - 1];
            //try to find the control with findcontrol, in this case with master pages
            object control = this.Master.FindControl("mainContentPane").FindControl(controlID) as object;
            //check if the control exist and if it is a textbox
            if (control != null && control is TextBox)
            {
                //cast the object to the actual textbox
                TextBox tb = control as TextBox;
                //loop all the attributes of the textbox
                foreach (string attr in tb.Attributes.Keys)
                {
                    //get the key and value of the attribute
                    Response.Write(attr + ": " + tb.Attributes[attr] + "<br>");
                }
            }
        }
    }
