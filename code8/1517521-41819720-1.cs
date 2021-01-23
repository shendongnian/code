    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
                DropDownList2.Items.Clear();
                switch (DropDownList1.Text)
                {
                    case "Caesar Tools":
                        DropDownList2.Items.Add("Caesar Bruteforce");
                        DropDownList2.Items.Add("ROT-1");
                        DropDownList2.Items.Add("ROT-2");
                        DropDownList2.SelectedIndex = 1;
                        DropDownList2.DataBind();
                        break;
                    case "ASCII Tools":
                        DropDownList2.Items.Add("Decimal to ASCII");
                        DropDownList2.Items.Add("Hex to ASCII");
                        DropDownList2.Items.Add("Binary to ASCII");
                        DropDownList2.SelectedIndex = 0;
                        DropDownList2.DataBind();
                        break;
                    default:
                        break;
                }
            }
