    private void combo_main_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((string)combo_main_type.SelectedItem == "Jewelry")
        {
            txt_qty.Visible = true;
            label6.Visible = true;
            txt_qty.Location = new System.Drawing.Point(213, 343);
            label6.Location = new System.Drawing.Point(40, 348);
            textBox5.Visible = false;
            label18.Visible = false;
        }
        else if ((string)combo_main_type.SelectedItem == "Gem")
        {
            textBox5.Visible = true;
            label18.Visible = true;
            textBox5.Location = new System.Drawing.Point(213, 343);
            label18.Location = new System.Drawing.Point(40, 348);
            txt_qty.Visible = false;
            label6.Visible = false;
        }
        else
        {
            textBox5.Visible = false;
            label18.Visible = false;
            txt_qty.Visible = false;
            label6.Visible = false;
        }
    }
