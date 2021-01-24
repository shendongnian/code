    private void BtnRemoveTextbox2_Click(object sender, EventArgs e)
    {
        foreach (Control ctrl in this.Controls) 
        {
            if (ctrl.Name == "Textbox2")
              this.Controls.Remove(ctrl);
        }
    }
