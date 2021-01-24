    if (string.Equals(propNameValue, nameof(UserParameters.CtxCfgPresent), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxCfgPresent = BitConverter.ToUInt32(propValueValue, 0);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxCfgFlags1), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxCfgFlags1 = (CtxCfgFlags1) BitConverter.ToUInt32(propValueValue, 0);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxCallBack), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxCallBack = BitConverter.ToUInt32(propValueValue, 0);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxKeyboardLayout), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxKeyboardLayout = BitConverter.ToUInt32(propValueValue, 0);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxNwLogonServer), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxNwLogonServer = BitConverter.ToUInt32(propValueValue, 0);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxMaxConnectionTime), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxMaxConnectionTime = BitConverter.ToUInt32(propValueValue, 0);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxMaxDisconnectionTime), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxMaxDisconnectionTime = BitConverter.ToUInt32(propValueValue, 0);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxMaxIdleTime), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxMaxIdleTime = BitConverter.ToUInt32(propValueValue, 0);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxShadow), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxShadow = (CtxShadow) BitConverter.ToUInt32(propValueValue, 0);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxMinEncryptionLevel), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxMinEncryptionLevel = propValueValue[0];
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxWfHomeDir), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxWfHomeDir = Encoding.ASCII.GetString(propValueValue, 0, propValueValue.Length - 1);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxWfHomeDirDrive), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxWfHomeDirDrive = Encoding.ASCII.GetString(propValueValue, 0, propValueValue.Length - 1);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxInitialProgram), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxInitialProgram = Encoding.ASCII.GetString(propValueValue, 0, propValueValue.Length - 1);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxWfProfilePath), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxWfProfilePath = Encoding.ASCII.GetString(propValueValue, 0, propValueValue.Length - 1);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxWorkDirectory), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxWorkDirectory = Encoding.ASCII.GetString(propValueValue, 0, propValueValue.Length - 1);
    }
    else if (string.Equals(propNameValue, nameof(UserParameters.CtxCallbackNumber), StringComparison.OrdinalIgnoreCase))
    {
      userParameters.CtxCallbackNumber = Encoding.ASCII.GetString(propValueValue, 0, propValueValue.Length - 1);
    }
    else
    {
      throw new Exception("Unsupported property.");
    }
