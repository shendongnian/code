    protected void Button1_Click(object sender, EventArgs e)
    {
       List<string> selectedFood = new List<string>();
       foreach (Control ctrl in form1.Controls)
       {
           if (ctrl is CheckBox)
           {
               CheckBox chkBox = ctrl as CheckBox;
               if (chkBox.Checked)
               {
                    selectedFood.Add(chkBox.Text);
               }
           }
       }
       Label1.Text = String.Join(",", selectedFood);
    }
