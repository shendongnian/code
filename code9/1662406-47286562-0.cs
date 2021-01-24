    public static DataTable GenerateDataGridFromMetaData(List<ObservableCollection<DocumentMetaData>> dataList)
    {
        try
        {
            if (dataList.Count > 0)
            {
                        DataTable dataTable = new DataTable();
                        List<int> skipColumn = new List<int>();
                        for (int index = 0; index < dataList.Count; index++)
                        {
                            ObservableCollection<DocumentMetaData> metaDataList = dataList[index];
                            List<string> values = new List<string>();
                            for (int metaDataIndex = 0; metaDataIndex < metaDataList.Count; metaDataIndex++)
                            {
                                DocumentMetaData docMetaData = metaDataList[metaDataIndex];
                                if (index == 0)
                                {
                                    if (!dataTable.Columns.Contains(docMetaData.Title))
                                    {
                                        dataTable.Columns.Add(docMetaData.Title);
                                        values.Add(docMetaData.Value); 
                                    }
                                    else
                                    {
                                        skipColumn.Add(metaDataIndex);
                                    }
                                }
                                else
                                {
                                    if (!skipColumn.Contains(metaDataIndex))
                                    {
                                        values.Add(docMetaData.Value); 
                                    }
                                }
                            }
                            dataTable.Rows.Add(values);
                        }
                        return dataTable;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                }    
            }
