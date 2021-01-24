    PlaceHolder1.Controls.Add(getCompleteRadioButtonList(ba));
    public RadioButtonList getCompleteRadioButtonList(BitArray ba)
    {
        //create a new radiobuttonlist
        RadioButtonList rbl = new RadioButtonList();
        //do the binding
        rbl.DataSource = ba;
        rbl.DataTextFormatString = " ";
        rbl.DataBind();
        //loop the values to set the items that were just bound
        for (int i = 0; i < ba.Count; i++)
        {
            rbl.Items[i].Selected = ba[i];
        }
        //return the list
        return rbl;
    }
