       private void btn_export_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = "Response.xls";
                savefile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                if (dset.Tables[0].Rows.Count > 0)
                {
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        //using (StreamWriter sw = new StreamWriter(savefile.FileName))
                        //    sw.WriteLine("Hello World!");
                        StreamWriter wr = new StreamWriter(savefile.FileName);
                        for (int i = 0; i < dset.Tables[0].Columns.Count; i++)
                        {
                            wr.Write(dset.Tables[0].Columns[i].ToString().ToUpper() + "\t");
                        }
                        wr.WriteLine();
                        //write rows to excel file
                        for (int i = 0; i < (dset.Tables[0].Rows.Count); i++)
                        {
                            for (int j = 0; j < dset.Tables[0].Columns.Count; j++)
                            {
                                if (dset.Tables[0].Rows[i][j] != null)
                                {
                                    wr.Write(Convert.ToString(dset.Tables[0].Rows[i][j]) + "\t");
                                }
                                else
                                {
                                    wr.Write("\t");
                                }
                            }
                            //go to next line
                            wr.WriteLine();
                        }
                        //close file
                        wr.Close();
                        MetroMessageBox.Show(this, "Data saved in Excel format at location "+ savefile.FileName , "Successfully Saved", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this,"Zero record to export , perform a operation first","Can't export file",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, v1.PrintExceptionDetails(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                el.LogError(ex);
            }
            finally
            {
            }
        }
