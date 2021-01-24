    public void btn_runGRM_Click(object sender, EventArgs e)
        {
            this.btn_runGRM.Enabled = false;
            this.checkBox_Assgn.Enabled = false;
            this.checkBox_Avail.Enabled = false;
            this.checkBox_RFI.Enabled = false;
            this.checkBox_Census.Enabled = false;
            this.ChartDGV.Visible = true;
            if (checkBox_Assgn.Checked)
            {
                AssignmentDGV.DataSource = null;
                AssignmentDGV.Rows.Clear();
                AssignmentDGV.Refresh();
                ThreadStart childref1 = new ThreadStart(CallToChildthread1);
                Thread mt1 = new Thread(childref1);
                MakeThread1(childref1);
            }
            if (checkBox_Assgn.Checked || checkBox_RFI.Checked)
            {
                while (chart1.Series.Count > 0) { chart1.Series.RemoveAt(0); }
                chart1.Visible = true;
                ChartDGV.DataSource = null;
                ChartDGV.Rows.Clear();
                ChartDGV.Refresh();
                ThreadStart childref3 = new ThreadStart(CallToChildthread3);
                Thread mt3 = new Thread(childref3);
                MakeThread3(childref3);
            }
