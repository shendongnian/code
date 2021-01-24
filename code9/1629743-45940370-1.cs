    private void BtnRemoveTextbox2_Click(object sender, EventArgs e)
    {
        foreach (Controls ctrl in this.Controls) 
        {
            if (ctrl.ID == "text2")
              this.Controls.Remove(ctrl);
        }
    }
