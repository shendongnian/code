    foreach(Control c in groupBox1.Controls)
    {
     if(c is CheckBox)
     {
       CheckBox cb = (CheckBox)c;
        if(cb.Checked == false)
        {
           cb.Checked = true;
        }
        else
        {
           cb.Checked = false;
        }
     }
    }
