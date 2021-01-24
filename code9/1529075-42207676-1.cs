    private Item_DataColl thread_command_READ_result(object parameter)
        {
            readingThreadParameter p = parameter as readingThreadParameter;
            Item item;
            if (p.UCPT_Name != null)
            {
                Item_DataColl resultSet;
                try
                {
                    OnProgressBarUpdate(progressBar.UnknownEnd);
                    resultSet = connector.command_READ(p.UCPT_Name);
                    readOperationDone(resultSet);
                    OnConsoleWriting(string.Format("[READING] Lecture réussie : {0} = {1}", ((Dp_Data)resultSet.Item[0]).UCPTname, ((Dp_Data)resultSet.Item[0]).UCPTvalue[0].Value), ILonConnectorConsoleResultType.RESULT);
                    if (OnResultSetComplete != null) OnResultSetComplete(resultSet); 
                }
                catch (Exception e)
                {
                    OnConsoleWriting(e.ToString(), ILonConnectorConsoleResultType.ERROR);
                }
                finally
                {
                    OnProgressBarUpdate(progressBar.Invisible);
                }
            }
        }
