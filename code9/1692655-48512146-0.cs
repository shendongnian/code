    cboSort2.Enabled = !pnlSort1.Visible && pnlSort3.Visible;
    cboDir2.Enabled = !pnlSort1.Visible && pnlSort3.Visible;
    pnlSort2.Visible = !pnlSort1.Visible && pnlSort3.Visible;
    cboSort3.Enabled = (cboSort2.SelectedIndex > -1 && cboDir2.SelectedIndex > -1);
    cboDir3.Enabled = (cboSort2.SelectedIndex > -1 && cboDir2.SelectedIndex > -1);
    pnlSort3.Visible = (cboSort2.SelectedIndex > -1 && cboDir2.SelectedIndex > -1);
