     string[] headerDictionary =
                    {
                        Properties.Resources.yourKeyHere,
                        Properties.Resources.yourKeyHere,
                        Properties.Resources.yourKeyHere,
                        Properties.Resources.yourKeyHere,
                        (...)
                    };
                for (int i = 0; i < this.ResultDataGrid.Columns.Count; i++)
                {
                    DataGridColumn dgc = this.ResultDataGrid.Columns[i];
                    dgc.Header = headerDictionary[i];
                    dgc.Width = DataGridLength.SizeToCells;
                }
