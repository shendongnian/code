    public static class Env
    {
        public static readonly bool Debugging =
          Convert.ToBoolean(WebConfigurationManager.AppSettings["Debugging"]);
    }
