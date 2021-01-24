    private void GrdVw_Reception_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
            {
                if (GrdVw_Reception.CurrentCellAddress.X == 0)
                {
    
                    if (Convert.ToBoolean(GrdVw_Reception.Rows[e.RowIndex].Cells[0].Value) == false)
                    {
                        GrdVw_Reception.Rows[e.RowIndex].Cells[0].Value = CheckState.Checked;
                    }
                    else
                    {
                        GrdVw_Reception.Rows[e.RowIndex].Cells[0].Value = CheckState.Unchecked;
                    }
    
                    int UpTpOne = 0;
    
                    bool flag = false;
    
                    for (int i = 0; i < GrdVw_Reception.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(GrdVw_Reception.Rows[i].Cells["checkColumn"].Value) == true)
                        {
                            UpTpOne++;
    
                            if (UpTpOne == 1)
                            {
                                flag = true;
                            }
                            else
                            {
                                flag = false;
                            }
    
                        }
                    }
    
                    if (UpTpOne == 0)
                    {
                        Btn_DelRecord.Visible = false;
    
                    }
                    else
                    {
                        Btn_DelRecord.Visible = true;
                    }
    
                    if (flag == true)
                    {
                        Btn_Edit.Visible = true;
                    }
                    else
                    {
                        Btn_Edit.Visible = false;
                    }
                }
            }
