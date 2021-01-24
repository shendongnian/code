              private void function()
        {
          
            int SelectResult = 0;
            if (DataSelector.RowCount != 0)
            {
                for (int i = 0; i < DataSelector.RowCount; i++)
                {
                    bool value = false;
                    if (DataSelector.Rows[i].Cells["Select"].Value != null)
                    {
                        value = (bool)DataSelector.Rows[i].Cells["Select"].Value;
                        if (value)
                        {
                          
                               int ar = 0;
                               bool r = int.TryParse(DataSelector.Rows[i].Cells["Paid"].Value.ToString(), out ar);
                                if (r)
                                {
                                    SelectResult += ar;
                                }
                        }
                        
                    }
                }
                    
            }
    // SelectAmount is Label
            SelectAmount.Text = SelectResult.ToString();
        }
