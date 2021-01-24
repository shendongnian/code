      try
                    {
                        if (e.Value != null)
                        {
                            // Check for the string "pink" in the cell.
                            string stringValue = (string)e.Value;
                            stringValue = stringValue.ToUpper();
                            if ((stringValue.IndexOf("PRESENT") > -1))
                            {
                                e.CellStyle.BackColor = Color.Green;
                            }
                            else
                            {
                                e.CellStyle.BackColor = Color.Red;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
    
                }
