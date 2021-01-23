    Process acadProc = new Process();
    acadProc.StartInfo.FileName = "C:/Program Files/Autodesk/AutoCAD 2015/acad.exe";
    acadProc.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
    acadProc.Start();
    if (!acadProc.WaitForInputIdle(300000))
      throw new ApplicationException("Acad takes too much time to start.");
    AcadApplication acadApp;
    while (true)
    {
      try
      {
        acadApp = Marshal.GetActiveObject("AutoCAD.Application.20");
        return;
      }
      catch (COMException ex)
      {
        const uint MK_E_UNAVAILABLE = 0x800401e3;
        if ((uint) ex.ErrorCode != MK_E_UNAVAILABLE) throw;
        Thread.Sleep(1000);
      }
    }
    while (true)
    {
      AcadState state = acadApp.GetAcadState();
      if (state.IsQuiescent) break;
      Thread.Sleep(1000);
    }
