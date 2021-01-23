        private bool Merge(DataTable target, DataTable source, bool preserve)
        {           
            if (!preserve)
            {
                target.Merge(source, false);
                return true;
            }            
            else
            {
                DataRow drTargetMatch;
                DataRow drNew;
                int numCol = source.Columns.Count;
                int index = 1;
                try
                {
                    foreach (DataRow dr in source.Rows)
                    {
                        drTargetMatch = target.Rows.Find(dr[0]);
                        if (drTargetMatch == null) // source row does not exist in target, add a copy
                        {
                            drNew = target.NewRow();
                            drNew.ItemArray = dr.ItemArray;
                            target.Rows.Add(drNew);
                        }
                        else // source row exists in target, update empty values
                        {
                            for (index = 1; index < numCol; index++) // start at 1 since we don't update PK
                            {
                                if (drTargetMatch.IsNull(index) && !dr.IsNull(index))
                                    drTargetMatch[index] = dr[index];                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    target.RejectChanges();
                    return false;
                }
                
                return true;
            }                        
        }
