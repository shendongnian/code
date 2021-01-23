    public override void OnBeforeSave(object sender, Document aDocument)
    {
      if (false == myCompileCommandFlag)
        return;
      // write your code here 
      
    }
    public void CommandEventsBeforeExecute(string aGuid, int aId, object aCustomIn, object aCustomOut, ref bool aCancelDefault)
    {
      string commandName = GetCommandName(aGuid, aId);
      if (0 != string.Compare("Build.Compile", commandName))
      {
        return;
      }
      myCompileCommandFlag= true;
    }
    public string GetCommandName(string aGuid, int aId)
    {
      if (null == aGuid)
        return string.Empty;
      if (null == mCommand)
        return string.Empty;
      Command cmd = mCommand.Item(aGuid, aId);
      if (null == cmd)
        return string.Empty;
      return cmd.Name;
    }
