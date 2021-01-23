    private void PrintScheduleBtn_Click(object sender, EventArgs e)
    {
    
        if (StaffATB.Text != "" && HelperTeamATB.Text != "" && StaffBTB.Text != "" && HelperTeamBTB.Text != "" && StaffCTB.Text != "" && HelperTeamCTB.Text != "" && StaffDTB.Text != "" && HelperTeamDTB.Text != "")
        {
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin menyimpan jadwal pengisian ?", "", MessageBoxButtons.YesNo);
    
            if (dialogResult == DialogResult.Yes)
            {
                // create an FileInfo instance
                var file = new FileInfo(lokasifile);
                // use the contructor that take an FileInfo
                // wrap in a using so stuff gets disposed nicely
                using (ExcelPackage pck = new ExcelPackage(file))
                {
                    var rekap = pck.Workbook.Worksheets[1];
    
                    // the rest of your code here
    
                    // the rest of your code is above
                    // explicitely Save the changes
                    pck.Save();
                }
            }
        }
    }
