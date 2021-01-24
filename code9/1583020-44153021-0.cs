                DataTable ss = new DataTable();
                ss.Columns.Add("ID");
                ss.Columns.Add("Text");
                ss.Columns.Add("Highlight");
                ss.Columns.Add("Cursor");
                ss.Columns.Add("Description");
                ss.Columns.Add("Next");
                DataRow row = ss.NewRow();
                row["ID"] = findResults[0].Id;
                row["Text"] = findResults[0].Text;
                row["Highlight"] = findResults[0].Highlight;
                row["Cursor"] = findResults[0].Cursor;
                row["Description"] = findResults[0].Description;
                row["Next"] = findResults[0].Next;
                ss.Rows.Add(row);
                foreach (DataRow Drow in ss.Rows)
                {
                    int num = dataGridView1.Rows.Add();
                    dataGridView1.Rows[num].Cells[0].Value = Drow["id"].ToString();
                    dataGridView1.Rows[num].Cells[1].Value = Drow["Text"].ToString();
                    dataGridView1.Rows[num].Cells[2].Value = Drow["Highlight"].ToString();
                    dataGridView1.Rows[num].Cells[3].Value = Drow["Cursor"].ToString();
                    dataGridView1.Rows[num].Cells[4].Value = Drow["Description"].ToString();
                    dataGridView1.Rows[num].Cells[5].Value = Drow["Next"].ToString();
                }
                
                if (txt_Search.Text.Length <= 2)// if less than two letters are entered nothing is displayed on the list.
                {
                    MessageBox.Show("Please enter more than 2 Chars!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                findResults.Clear();
 
