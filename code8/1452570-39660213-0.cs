    private void btnEditItem_Click(object sender, EventArgs e)
    {
        using (Form3 form3 = new Form3()}
        {
            var dlgResult = form3.ShowDialog(); // show form 3 as a modal dialog box
            // halt this procedure until form3 is closed
            // handle the result of form3:
            if (dlgResult == DialogResult.OK)
            {
                var x = form3.SomePropery;
                ProcessDialogOutput(x);
            }
        }
    }
