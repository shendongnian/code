    public string BuildMethodCall(string MethodName, params object[] Args)
    {
      object[] tmpArgs = new object[Args.Length];
      for (int i = 0; i < Args.Length; i++)
      {
        if (Args[i].GetType() == typeof(DateTime))
        {
          tmpArgs[i] = ((DateTime)Args[i]).ToString();
        }
        else
          tmpArgs[i] = Args[i];
      }
      String.Format(something, tmpArgs);
    }
