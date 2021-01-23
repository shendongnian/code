    class Reset
    {
        public void BlankAll(Form form, Panel pnl, string UserName)
        {          
            foreach (Control ch in pnl.Controls) 
            {
                if (ch.Name.Substring(ch.Name.Length - 3) != "_NI")
                {
                    if (ch is TextBox || ch is ComboBox)
                        ch.Text = string.Empty;
                    else if (ch is DateTimePicker)
                        ch.Text = DateTime.Now.ToShortDateString();
                    else if (ch is DataGridView)
                    {                        
                        DataGridView dgv = (DataGridView)pnl.Controls.Find(ch.Name, true).SingleOrDefault();
                        for (int i = dgv.Rows.Count - 1; i > 0; i--)
                        {
                            dgv.Rows.RemoveAt(i);
                        }
                        for (int i = 1; i < dgv.Columns.Count; i++)
                        {
                            dgv.Rows[0].Cells[i].Value = string.Empty;
                        }
                    }
                }
    
         Type tp = Type.GetType("HealthClub." + form.Name);
         object myobj = Activator.CreateInstance(tp);
         MethodInfo method = myobj.GetType().GetMethod("FillValues");   
         object[] parametersArray = new object[] {form, UserName };
         form.Refresh();
            }            
