    using (DataTable dt = new DataTable())
    {
        dt.Load(rd);
        Console.WriteLine(dt.Rows.Count);
    }
    if (Convert.ToInt32(rd["B_Quan"].ToString()) > 3)
    {
        MessageBox.Show("Oops sobra tama na ");
    }
