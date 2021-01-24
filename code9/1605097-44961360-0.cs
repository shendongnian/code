                int numberOfCols = Table.Columns.Count;
                for (int i = Table.Rows.Count - 1; i >= 0; i--)
                {
                    Boolean delete = true;
                    for (int j = 0; j < numberOfCols; j++)
                    {
                        if (Table.Rows[i][j] != null)
                        {
                            delete = false;
                            break;
                        }
                    }
                    if (delete)
                    {
                        Table.Rows.Remove(Table.Rows[i]);
                    }
                }
