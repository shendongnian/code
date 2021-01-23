    private void xtraTabControl1_MouseDown(object sender, MouseEventArgs e)
    {
        DevExpress.XtraTab.ViewInfo.XtraTabHitInfo hi = xtraTabControl1.CalcHitInfo(e.Location);
        if (hi.HitTest == DevExpress.XtraTab.ViewInfo.XtraTabHitTest.PageHeader)
        {                                
            MessageBox.Show(hi.Page.Text.ToString()) );
        }
    }
