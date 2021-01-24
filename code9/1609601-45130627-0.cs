    public static void CustomizeGrid(RadGridView Gridview)
    {
       // check if Invoke is needed
       if (Gridview.InvokeRequired) 
       {
          // Yes, so invoke on the Control instance that was supplied
          Gridview.Invoke(new MethodInvoker(delegate {
            // makes the same call but now you''ll be on the UI thread
            CustomizeGrid(Gridview);
           }));
          return;
       } 
       // all your other logic here
    }
