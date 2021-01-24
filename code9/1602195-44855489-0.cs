    private Data.Grade ReadStudentGrades()
    {
        Data.Grade grd = new Data.Grade();
        grd.FakNumber = txtFakNumber.Text;
        grd.Math = Int32.Parse(txtMath.Text);
        grd.Physic = Int32.Parse(txtPhysic.Text);
        grd.PIK = Int32.Parse(txtPIK.Text);
        grd.OIP = Int32.Parse(txtOIP.Text);
        grd.SAA = Int32.Parse(txtSAA.Text);
        grd.PS = Int32.Parse(txtPS.Text);
        grd.PMU = Int32.Parse(txtPMU.Text);
        grd.KP = Int32.Parse(txtKP.Text);
        grd.ASLS = Int32.Parse(txtASLS.Text);
        grd.PE = Int32.Parse(txtPE.Text);
        grd.FakNumber = txtFakNumber.Text;
        return grd;
    }
