    private class MyColumnRenderer : BrightIdeasSoftware.BaseRenderer
    {
          public override bool RenderSubItem(DrawListViewSubItemEventArgs e, Graphics g, Rectangle cellBounds, object x)
          {
              //do you own stuff here
    
              //default rendering
              return base.RenderSubItem(e, g, cellBounds, x);
          }
    }
    //...
    olvColumn2.Renderer = new MyColumnRenderer();
