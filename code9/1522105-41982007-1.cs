    await Process(async () => await ClientMethod()).Invoke();
    public static async Task ClientMethod()
    {
      throw new Exception("Test");
    }
