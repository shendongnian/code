    private void CheckForDisks()
    {
      if (Directory.Exists(@"C:\"))
      {
        buttonC.Visible = true;
      }
      if (Directory.Exists(@"D:\"))
      {
        buttonD.Visible = true;
      }
      if (Directory.Exists(@"E:\"))
      {
        buttonE.Visible = true;
      }
      // and so on... you can also do this with a loop, look up Adarsh Ravi answer for this
    }
