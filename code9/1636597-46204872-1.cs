    private async void btnShowDialogControl_Click(object sender, EventArgs e)
    {
        var control = new DialogControl();
        splitContainer1.Panel2.Controls.Add(control);
        //Disable your other controls here
        if (await control.ShowModalAsync() == DialogResult.OK) //Execution will pause here until the user closes the "dialog" (task completes), just like a modal dialog.
        {
            MessageBox.Show($"Username: {control.UserName}");
        }
        //Re-enable your other controls here.
        splitContainer1.Panel2.Controls.Remove(control);
    }
