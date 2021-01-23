     public Boolean IsDataGridViewEmpty( DataGridView dataGridView)
            {
                bool isEmpty = false;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //if (!string.IsNullOrEmpty(cell.Value.ToString ()))
                        //{
                            if (string.IsNullOrEmpty(cell.Value.ToString().Trim() ))
                            {
                                isEmpty = true;
                                break; // TODO: might not be correct. Was : Exit For
                          //  }
                        }
                    }
                }
                return isEmpty;
            }
