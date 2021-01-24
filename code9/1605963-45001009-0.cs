     DataRow[] dr = killTable.Select("" + cmVariables.ClassName + " = '" + cmbClasses.Text + "'");
                              
                string indexName = (killTable.Rows.IndexOf(dr[0])).ToString();
                                
                int i = Int32.Parse(indexName);
                killTable.Rows[i].Delete();
                DataTable killItTable = killTable.GetChanges(DataRowState.Deleted);
                
                killClass_Execution(killItTable, cmbClasses.Text, ShortClassNm);
