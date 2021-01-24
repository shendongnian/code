     private void btnUP_Click(object sender, EventArgs e)
            {
                if (dgv != null)
                {
                    if (dgv.Rows.Count > 0)
                    {
                        try
                        {
                            dgv.GridNavigator.SelectPreviousRow(1);
                        }
                        catch { }
                    }
                }
            }
            private void btnDown_Click(object sender, EventArgs e)
            {
                if (dgv != null)
                {
                    if (dgv.Rows.Count > 0)
                    {
                        try
                        {
                            dgv.GridNavigator.SelectNextRow(1);
                        }
                        catch { }
                    }
                }
                
            }
