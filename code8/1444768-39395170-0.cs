    private void GVTrabajadores_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridView gV = sender as GridView;
            for(int i = 0; i < gV.Columns.Count; i++)
            {
              Control c = e.Row.Cells[i].Controls[0];
                string controlType = c.GetType().ToString().Replace("System.Web.UI.WebControls.", "");
                switch (controlType)
                {
                    case "TextBox":
                        TextBox t = c as TextBox;
                        t.TextChanged += GVTrabajadores_TextBox_TextChanged;
                        t.AutoPostBack = true;
                        break;
                    case "CheckBox":
                        CheckBox cB = c as CheckBox;
                        cB.CheckedChanged += GVTrabajadores_CheckBox_Changed;
                        cB.AutoPostBack = true;
                        break;
                }
            }
        }
        private void GVTrabajadores_CheckBox_Changed(object sender, EventArgs e)
        {
            //process change
        }
        private void GVTrabajadores_TextBox_TextChanged(object sender, EventArgs e)
        {
            //process changed text
        }
