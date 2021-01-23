    private void btn_check_Click(object sender, EventArgs e)
    {
        string z1 = txt_CodePersonnelZ1.Text;
        var query = db.tbl_PrsAdds.Where(c => c.Personely.Length == z1.Length && c.Personely.Contains(z1)).Single();
        lbl_name.Text = query.Name;
    }
