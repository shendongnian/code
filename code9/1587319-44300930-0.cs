    for (int i = 0; i < rlv_CouponCode.Items.Count; i++)
    {
        CheckBox cb = (CheckBox)rlv_CouponCode.Items[i].FindControl("Checkbox1");
    
        if (cb.Checked)
        {
            int id = Convert.ToInt32(rlv_CouponCode.DataKeys[i].Values[0]);    
        }
    }
