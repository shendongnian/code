    string MyActualProcessingMethod(string it)
    {
      // Process the string and do some other stuff
      // and send a progress message downstream
      return SomeProgressMessage;
    }
    void UpdateTheUI(string msg)
    {
      statusBar1.Text = msg;
    }
    var myProcessingBlock = new TransformBlock<string,string>(msg =>MyActualProcessingMethod(msg));
