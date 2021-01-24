    TextBox ByIndex(int idx, Control parent)
    {
        TextBox result = null;
        string searchFor = string.Format(TB_NAME, idx);
        foreach(Control ctrl in parent.Controls)
        {
            if(!(ctrl is TextBox) && ctrl.HasChildren)
            {
                result = ByIndex(idx, ctrl);
                if( result != null)
                    break;
            }
            else if(ctrl is TextBox)
            {
                if(ctrl.Name = searchFor)
                {
                    result = ctrl as TextBox;
                    break;
                }
            }
        }
        return result;
    }
