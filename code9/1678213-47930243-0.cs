      protected void Button1_Click(object sender, EventArgs e)
        {
            IngredientQuantityControl uc = (IngredientQuantityControl)Page.LoadControl("IngredientQuantityControl.ascx");
            uc.SetLabelText("Halleluyah!");
            Panel1.Controls.Add(uc);
            //string text = listBox1.GetItemText(listBox1.SelectedItem);
        }
