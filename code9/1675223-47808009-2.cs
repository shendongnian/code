    private void SaveToFiles(DataTable srcData)
            {
                if (srcData.Rows.Count > 0)
                {
                    int FileStart = 0;
                    int FileEnd = -1;
    
                    while (FileStart < srcData.Rows.Count)
                    {
                        for (int row = FileStart; row < srcData.Rows.Count; row++)
                        {
                            if (string.IsNullOrEmpty(srcData.Rows[row].Field<string>(0)) == false)
                            {
                                FileStart = row;
                            }
                            if (string.IsNullOrEmpty(srcData.Rows[row].Field<string>(4)) == false)
                            {
                                FileEnd = row;
                                break;
                            }
                        }
    
                        var data = srcData.AsEnumerable().Skip(FileStart).Take(FileEnd - FileStart + 1);
                        SaveFile(data.ToList());
                        FileStart = FileEnd + 1;
                    }
                }
            }
