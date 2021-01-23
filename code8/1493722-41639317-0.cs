    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
      // WM_CLOSE = 16
      if (16 == m.Msg)
      {
          //closing
          axAcroPDF1.LoadFile("UNLOAD_FILE_FOR_FUDGE");
               // we need to wait a bit
                System.Threading.Thread.Sleep(500);
            }
            base.WndProc(ref m);
     }
