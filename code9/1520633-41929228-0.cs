       public static string getDataGridColumnNameAt(DataGrid dGrid, int columnIndex)
            {
                string sRet = "";
                try
                {
                    if (dGrid.SelectedItem == null)
                    {
                        sRet = "";
                    }
                    else
                    {
                        string str = dGrid.SelectedItem.ToString(); // Take the selected line
                        str = str.Replace("}", "").Trim().Replace("{", "").Trim(); // Delete useless characters
                        if (columnIndex < 0 || columnIndex >= str.Split(',').Length) // case where the index can't be used 
                        {
                            sRet = "";
                        }
                        else
                        {
                            str = str.Split(',')[columnIndex].Trim();
                            str = str.Split('=')[0].Trim();
                            sRet = str;
                        }
                    }
                }
                catch (Exception ex)
                {
                    string sEx = ex.ToString();
                }
                return sRet;
            }
