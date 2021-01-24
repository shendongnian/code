    private void BtnNext_Click(object sender, EventArgs e)
    {
        this.Visible = false;
        Grading_Section g = new Grading_Section();
        g.DisableTextBoxes(comboboxValue);
        g.Show();    
    }
