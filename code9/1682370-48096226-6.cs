    public class Department
    {
        public int ID { get; set; }
        public int RemainingDept { get; set; }
    }
    private void button2_Click(object sender, EventArgs e)
    {
        List<Department> liste = new List<Department>();
        OleDbCommand cmd = new OleDbCommand("SELECT ID, RemainingDept FROM Dept_Tbl ORDER BY RemainingDept", conn);
        OleDbDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            var dept = new Department()
            {
                ID = Convert.ToInt32(dr["ID"]),
                RemainingDept = Convert.ToInt32(dr["RemainingDept"]);
            };
            liste.Add(dept);
        }
        foreach(var nItem in liste)
        {
            listBox3.Items.Add(nItem.ID + " " + nItem.RemainingDept);
        }
    }
