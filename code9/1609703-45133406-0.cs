    public List<string> GetStudents()
    {
        return null;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        using(var ed = new DataClasses1DataContext())
        {
            List<string> lstStudents = GetStudents();
            var tst = 
                (from c in ed.Baleni
                where (lstStudents ?? new List<string>()).Contains(c.b_poznamka)
                select c)
            .ToList();
        }
    }
