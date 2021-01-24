     SqlParameter[] Prms = new SqlParameter[] {
                new SqlParameter("desemp", desemp.Text),
                new SqlParameter("valu", valu.Text),
                new SqlParameter("fs", fs.Text),
                new SqlParameter("sel", sel.Text),
                new SqlParameter("desc", desc.Text),
                new SqlParameter("ench", ench.Text),
                new SqlParameter("comp", comp.Text),
            };
 
    cmd.Parameters.AddRange(Prms);
