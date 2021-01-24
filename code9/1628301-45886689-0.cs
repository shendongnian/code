     for (int i = 0; i < dgvBaleDisposition.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvBaleDisposition.Rows[i]
                                          .Cells[0].Value) == true)
                    {
                        dgvBaleDisposition.Rows.RemoveAt(i);
                    }
                    i = i - 1;
                    j = j + 1;
                    if (j == countRows)
                    {
                        break;
                    }
                }
