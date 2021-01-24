     protected void AreaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
            {
     if (AreaDropDownList.SelectedItem.Text == "")
    {
    inputbox1.Visible = false;
                    inputbox2.Visible = false;
                    inputbox3.Visible = false;
                    }
    else if (AreaDropDownList.SelectedItem.Text == "Rectangle")
                {
    inputbox1.Visible = true;
                    inputbox2.Visible = true;
                    inputbox3.Visible = false;
                }
    else if (AreaDropDownList.SelectedItem.Text == "Triangle")
                {
                   inputbox1.Visible = true;
                    inputbox2.Visible = true;
                    inputbox3.Visible = false;
                }
    else if (AreaDropDownList.SelectedItem.Text == "Trapezoid")
                {
    inputbox1.Visible = true;
                    inputbox2.Visible = true;
                    inputbox3.Visible = true;
                }
    else if (AreaDropDownList.SelectedItem.Text == "Circle")
                {
    inputbox1.Visible = true;
                    inputbox2.Visible = false;
                    inputbox3.Visible = false;
                }
    else if (AreaDropDownList.SelectedItem.Text == "Sector")
                {
                   inputbox1.Visible = true;
                    inputbox2.Visible = true;
                    inputbox3.Visible = false;
                }
    else if (AreaDropDownList.SelectedItem.Text == "Ellipse")
                {
    inputbox1.Visible = true;
                    inputbox2.Visible = true;
                    inputbox3.Visible = false;
                }
                else
                {
                    inputbox1.Visible = true;
                    inputbox2.Visible = true;
                    inputbox3.Visible = true;
                }
