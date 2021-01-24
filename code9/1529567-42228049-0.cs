    public async Task<Item_DataColl> invoke_command_READ(string UCPTName)
    {
      Item_DataColl resultSet = null;
      if (UCPTName != null)
      {
        try
        {
          OnProgressBarUpdate(progressBar.UnknownEnd);
          resultSet = await connector.command_READAsync(UCPTName);
          readOperationDone(resultSet);
          OnConsoleWriting(string.Format("[READING] Lecture réussie : {0} = {1}", ((Dp_Data)resultSet.Item[0]).UCPTname, ((Dp_Data)resultSet.Item[0]).UCPTvalue[0].Value), ILonConnectorConsoleResultType.RESULT);
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
      return resultSet;
    }
    internal Task<Item_DataColl> readAsync(string UCPTName)
    {
      return ilonBind.invoke_command_READ("Net/LON/10/LampDali1/nviRunHours");
    }
