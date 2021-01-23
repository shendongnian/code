    public void searching_query()
            {
                string grid_query = "";
                int cnt_coma = 0;
                string q_type = "";
                if (txt_marks.Text != "")
                {
                    string marks = Convert.ToString(txt_marks.Text);
                }
                if (cmbQType.SelectedIndex != -1)
                {
                    q_type = Convert.ToString(cmbQType.SelectedValue);
                    // Removing the wild character in question type . 
                    if (q_type.Contains("[") || q_type.Contains("]") || q_type.Contains("*") || q_type.Contains("%"))
                    {
                        q_type = replacestring(q_type);
                    }
                }
                // counting the number of fields has been enter ->(for entering "and" in between in query)
                {
                    if (txt_std.Text != "")
                        cnt_coma = 1;
                    if (txt_sub.Text != "")
                        cnt_coma = 2;
                    if (Txt_chp.Text != "")
                        cnt_coma = 3;
                    if (cmbQType.SelectedIndex != -1)
                        cnt_coma = 4;
                    if (txt_marks.Text != "")
                        cnt_coma = 5; 
                }
                // making query for searching . 
    
                if (txt_std.Text != "")
                {
                    if (cnt_coma > 1)
                        grid_query = grid_query + "Standard Like  '" + txt_std.Text.ToString() + "' and ";
                    else if (cnt_coma <= 1)
                        grid_query = grid_query + "Standard Like '" + txt_std.Text.ToString() + "'";
                }
                if (txt_sub.Text != "")
                {
                    if (cnt_coma > 2)
                        grid_query = grid_query + "Subject Like  '" + txt_sub.Text.ToString() + "%' and ";
                    else if (cnt_coma <= 2 )
                        grid_query = grid_query + "Subject Like  '" + txt_sub.Text.ToString() + "%' ";
                }
                if (Txt_chp.Text != "")
                {
                    if (cnt_coma > 3)
                        grid_query = grid_query + "Chapter Like  '" + Txt_chp.Text.ToString() + "%' and ";
                    else if (cnt_coma <= 3 )
                        grid_query = grid_query + "Chapter Like  '" + Txt_chp.Text.ToString() + "%'";
                }
                if (cmbQType.SelectedIndex != -1)
                {
                    if (cnt_coma > 4)
                        grid_query = grid_query + "QuestionType Like '" + q_type + "' and ";
                    else if (cnt_coma <= 4 )
                        grid_query = grid_query + "QuestionType Like '" + q_type + "'";
                }
                if (txt_marks.Text != "")
                {
                    grid_query = grid_query + "Marks = '" + Convert.ToString(txt_marks.Text) + "'";
                }
    
                //---------- Grid view Filteration 
                if (cnt_coma > 0)
                {             
                    DataTable dt = main_ds.Tables[0];
                    dt.DefaultView.RowFilter = String.Format(grid_query);
                    DGV_View.DataSource = main_ds.Tables[0].DefaultView;
                }
                else
                {
                    load_grid_view();
                }
                         
            }
