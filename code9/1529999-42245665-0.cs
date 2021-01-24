    for (int i = DropDownList1.Items.Count-1; i >0 ; i--)
            {
                if (DropDownList1.Items[i].Value.Contains("C-2"))
                {
                    DropDownList1.Items[i].Selected = true;
                    break;
                }
            }
