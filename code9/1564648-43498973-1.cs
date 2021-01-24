    private int _DwRegister;
    public MyClassName()
    {
      RegistrationServices rs;
      try
      {
        // Class constructor registers itself for COM
        rs = new RegistrationServices();
        if (!rs.RegisterAssembly(Assembly.GetExecutingAssembly(),
                                AssemblyRegistrationFlags.SetCodeBase))
        {
          throw new Exception
          ("Error registering MyClassName COM component.");
        }
        Guid guid = Marshal.GenerateGuidForType(typeof(SmartDesigner));
        Ole32.RegisterActiveObject(this, ref guid, 0, out _DwRegister);
      }
      catch (Exception ex)
      {
        throw new Exception(string.Format(
          "Error in {0} constructor:\r\n{1}",
          this.GetType().Name, ex.Message));
      }
      // End of MyClassName constructor
    }
