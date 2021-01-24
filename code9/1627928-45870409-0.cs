             for (int i = 0; i < RekapdataGridView.Rows.Count; i++)
                        {
                            for (int j = 0; j < RekapdataGridView.Columns.Count; j++)
                            {
                                count++;
                               If(count == 40)
                               {
                                  count = 0;
                                  coulumnnumb = coulumnnumb + 2;
                               }
                                XcelApp.Cells[i + 5, j + coulumnnumb] = string.Format("'{0}",RekapdataGridView.Rows[i].Cells[j].Value);                  
                            }
                        }
